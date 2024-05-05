using UnityEngine;

public class EmptyCheckStrategy : ISpawnCheckStrategy
{
    public bool IsCanBePlacedInPoint(Vector3 spawnPoint) => true;
}
