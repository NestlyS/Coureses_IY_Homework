using UnityEngine;

public class NoSaleStrategy : ISalesStrategy
{
    public void OnSale()
    {
        Debug.Log("�� ����� �����?! ��� �����.");
    }
}
