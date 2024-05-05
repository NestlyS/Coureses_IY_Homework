using UnityEngine;

public class BerserkSpecial : ISpecialStrategy
{
    public void UseSpecial()
    {
        Debug.Log("Увеличиваю урон стократно");
    }
}
