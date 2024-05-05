using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnTimeInSeconds;

    private readonly int _spawnCheckIterationsCount = 200;

    private IFactory _characterFactory;
    private ISpawnCheckStrategy _spawnChecker = new EmptyCheckStrategy();
    private Coroutine _spawnCoroutine;

    public bool IsSpawning { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }

    public void Init(IFactory characterFactory)
    {
        IsSpawning = false;
        SetFactory(characterFactory);
    }

    public void Init(IFactory characterFactory, ISpawnCheckStrategy spawnCheckStrategy)
    {
        _spawnChecker = spawnCheckStrategy;
        Init(characterFactory);
    }

    public void SetFactory(IFactory characterFactory)
    {
        Debug.Log($"Фабрика производила {_characterFactory?.GetName()}. Теперь производит {characterFactory.GetName()}.");
        _characterFactory = characterFactory;
    }

    public void StartSpawn()
    {
        IsSpawning = true;
        _spawnCoroutine = StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        IsSpawning = false;

        if (_spawnCoroutine != null) StopCoroutine(_spawnCoroutine);
    }

    public void SpawnOne()
    {
        Vector3 randomPoint = GetRandomPointInCircle();

        if (randomPoint == Vector3.zero)
        {
            Debug.Log("Не удалось найти точку для спауна");
            return;
        }

        MonoBehaviour character = _characterFactory.Get();
        character.transform.parent = transform;
        character.transform.position = randomPoint;
    }

    private Vector3 GetRandomPointInCircle()
    {
        for (int i = 0; i < _spawnCheckIterationsCount; i++)
        {
            Vector2 temp = Random.insideUnitCircle * _spawnRadius;
            Vector3 randomPoint = new(transform.position.x + temp.x, transform.position.y, transform.position.z + temp.y);

            if (_spawnChecker.IsCanBePlacedInPoint(randomPoint))
            {
                return randomPoint;
            }
        }

        return Vector3.zero;
    }

    IEnumerator Spawn()
    {
        while (IsSpawning)
        {
            yield return new WaitForSeconds(_spawnTimeInSeconds);
            SpawnOne();

            Debug.Log("------------");
        }
    }
}
