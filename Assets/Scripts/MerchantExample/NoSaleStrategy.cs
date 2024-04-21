using UnityEngine;

public class NoSaleStrategy : ISalesStrategy
{
    public void OnSale()
    {
        Debug.Log("Ты время видел?! Спи давай.");
    }
}
