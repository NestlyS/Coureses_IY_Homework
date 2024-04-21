using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] GunHolder _holder;

    private void Awake()
    {
        _holder.Init();
    }
}
