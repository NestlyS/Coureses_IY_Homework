using UnityEngine;

public interface ISpawnCheckStrategy
{
    bool IsCanBePlacedInPoint(Vector3 spawnPoint);
}
