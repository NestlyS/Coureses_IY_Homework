using UnityEngine;

public interface IFactory
{
    public string GetName();
    public MonoBehaviour Get();
}
