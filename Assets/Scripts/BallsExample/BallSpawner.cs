using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallColors _color;
    [SerializeField] private int _count;
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _spawnDelayInSeconds;

    private IBallListener _listener;

    public void Init(IBallListener listener)
    {
        _listener = listener;
    }

    public void Spawn()
    {
        StartCoroutine(SpawnAsync());
    }

    public void Clear()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            Destroy(transform.GetChild(i - 1).gameObject);
        }
    }

    IEnumerator SpawnAsync()
    {
        for(int i = 0; i < _count; i++)
        {
            yield return new WaitForSeconds(_spawnDelayInSeconds);
            GameObject ball = Instantiate(_ball, transform);
            if (ball.TryGetComponent(out Ball component))
            {
                component.Init(_color, _listener);
            }
        }
        yield return null;
    }
}
