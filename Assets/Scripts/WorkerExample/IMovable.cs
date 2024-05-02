using UnityEngine;

public interface IMovable
{
    public void MoveTo(Vector3 destination);
    public void TeleportTo(Vector3 destination);
    public bool IsNearPoint(Vector3 point);
}
