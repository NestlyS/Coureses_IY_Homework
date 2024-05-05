using UnityEngine;

public class PlaceTakenCheckStrategy : ISpawnCheckStrategy
{
    private float _checkRadius;
    private LayerMask _overlapCheck;

    public PlaceTakenCheckStrategy(float checkRadius, LayerMask overlapCheck)
    {
        _checkRadius = checkRadius;
        _overlapCheck = overlapCheck;
    }

    public bool IsCanBePlacedInPoint(Vector3 spawnPoint) {
        Collider[] colliders = Physics.OverlapSphere(spawnPoint, _checkRadius, _overlapCheck);
        return colliders.Length == 0;
    }
}
