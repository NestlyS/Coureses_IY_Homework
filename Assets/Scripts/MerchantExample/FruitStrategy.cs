using UnityEngine;

public class FruitStrategy : ISalesStrategy
{
    public void OnSale()
    {
        Debug.Log("Рано ещё, у меня только фрукты есть. Вчерашние. Будешь брать?");
    }
}
