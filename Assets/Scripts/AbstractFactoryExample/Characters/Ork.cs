using UnityEngine;

public class Ork : CharacterData
{
    public Ork(ISpecialStrategy specialStrategy) : base(specialStrategy)
    {

    }

    public override void TryUseSpecial()
    {
        Debug.Log("Я грозный орк и это мой особый прием:");
        base.TryUseSpecial();
    }
}
