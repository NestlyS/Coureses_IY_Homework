using UnityEngine;

[CreateAssetMenu(menuName = "Create Factory/Coin Factory")]
public class CoinFactory : ScriptableObject, IFactory
{
    [SerializeField] private Coin _prefab;

    public MonoBehaviour Get() {
        Coin instance = Instantiate(_prefab);
        instance.Init();
        return instance;
    }

    public string GetName() => GetType().Name;
}