using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _bulletPrefab;

    protected virtual void SpawnBullet(Vector3 position = default)
    {
        GameObject bulletInst = Instantiate(_bulletPrefab, _spawnPoint);
        if (position != Vector3.zero) bulletInst.transform.position = position;
        if (bulletInst.TryGetComponent(out Bullet bullet))
        {
            bullet.Init();
        }
    }

    public virtual void Init()
    {
    }

    public abstract void Shoot();
}
