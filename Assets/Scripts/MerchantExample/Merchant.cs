using UnityEngine;

public class Merchant : MonoBehaviour, IInteractable
{
    private ISalesStrategy _strategy;

    public void Init(ISalesStrategy salesStrategy)
    {
        SetStrategy(salesStrategy);
    }

    public void OnInteraction()
    {
        _strategy.OnSale();
    }

    public void SetStrategy(ISalesStrategy strategy)
    {
        _strategy = strategy;
    }
}
