using UnityEngine;

public class FruitStrategy : ISalesStrategy
{
    public void OnSale()
    {
        Debug.Log("���� ���, � ���� ������ ������ ����. ���������. ������ �����?");
    }
}
