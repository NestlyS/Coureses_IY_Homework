using System;
using UnityEngine;

public class ShooterWithMagazine : Shooter
{
    [SerializeField] private int _magazineSize;
    private Func<int, bool> _checkMagazineSize;
    private int _currentMagazine;

    public void Init(Func<int, bool> checkMagazineSize)
    {
        base.Init();
        _currentMagazine = _magazineSize;
        _checkMagazineSize = checkMagazineSize;
    }

    public override void Init()
    {
        base.Init();
        Init(CheckMagazineSize);
    }

    public override void Shoot()
    {
        SpawnBullet();
    }

    protected override void SpawnBullet(Vector3 position = default)
    {
        if (_checkMagazineSize(_currentMagazine))
        {
            Debug.Log("Магазин пуст!");
            return;
        }

        base.SpawnBullet(position);
        _currentMagazine--;
        Debug.Log($"Патронов в магазине: {_currentMagazine}");
    }

    private bool CheckMagazineSize(int val) => _currentMagazine <= 0;
}
