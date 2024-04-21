using UnityEngine;

public class ArmorStrategy : ISalesStrategy
{
    public void OnSale()
    {
        Debug.Log("О, ты пришел. Давай, заходи, у меня новый завоз брони.");
    }
}
