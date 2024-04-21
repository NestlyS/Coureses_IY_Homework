using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToLiveInMilliseconds;

    private const float DEFAULT_SPEED = 5.0f;
    private const float DEFAULT_TTL = 5.0f;

    public void Init(float speed = DEFAULT_SPEED, float ttl = DEFAULT_TTL)
    {
        _speed = speed;
        _timeToLiveInMilliseconds = ttl;
    }

    private void Update()
    {
        if (_speed <= 0) return;
        if (_timeToLiveInMilliseconds <= 0) Destroy(gameObject);

        transform.position += Vector3.forward;
        _timeToLiveInMilliseconds -= Time.deltaTime;
    }
}
