using UnityEngine;

public class Shotgun : ShooterWithMagazine
{
    public override void Init()
    {
        Init(CheckMagazine);
    }

    public override void Shoot()
    {
        base.SpawnBullet();
        base.SpawnBullet(transform.position - Vector3.left);
        base.SpawnBullet(transform.position - Vector3.right);
    }

    private bool CheckMagazine(int currentMagazine) => currentMagazine < 3;
}