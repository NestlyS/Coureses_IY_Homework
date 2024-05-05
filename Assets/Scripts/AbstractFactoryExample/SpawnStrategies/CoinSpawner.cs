using UnityEngine;

[RequireComponent (typeof(Spawner))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _coinSpawnRadius;
    [SerializeField] private LayerMask _coinSpawnLayerMask;

    private Spawner _spawner;

    public void Init(IFactory factory)
    {
        _spawner = GetComponent<Spawner>();
        _spawner.Init(factory, new PlaceTakenCheckStrategy(_coinSpawnRadius, _coinSpawnLayerMask));
    }

    public void StartSpawn() => _spawner.StartSpawn();

    public void SpawnOne() => _spawner.SpawnOne();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _coinSpawnRadius);
    }
}