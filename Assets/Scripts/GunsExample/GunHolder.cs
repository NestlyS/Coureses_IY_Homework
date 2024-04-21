using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _guns;
    [SerializeField] private List<Transform> _positions;

    private int _activeGunIndex;
    private ObjectSwapper _swapper;

    public void Init()
    {
        _guns.ForEach(gun =>
        {
            if (gun.TryGetComponent(out Shooter shooter))
            {
                shooter.Init();
            }
        });
        _swapper = new ObjectSwapper(_guns.Select(obj => obj.transform).ToList(), _positions);
        _activeGunIndex = 0;
    }

    public void SwapLeft()
    {
        _swapper.Left();
        if (_activeGunIndex <= 0)
        {
            _activeGunIndex = _guns.Count - 1;
            return;
        }

        _activeGunIndex--;
    }

    public void SwapRight()
    {
        _swapper.Right();
        if (_activeGunIndex >= _guns.Count - 1)
        {
            _activeGunIndex = 0;
            return;
        }

        _activeGunIndex++;
    }

    public void TriggerShoot()
    {
        if (_guns[_activeGunIndex].TryGetComponent(out Shooter shooter))
        {
            shooter.Shoot();
        }
    }
}
