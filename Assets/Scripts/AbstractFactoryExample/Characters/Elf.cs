using UnityEngine;

public class Elf : CharacterData
{
    public Elf(ISpecialStrategy specialStrategy) : base(specialStrategy)
    {

    }

    public override void TryUseSpecial()
    {
        Debug.Log("Я ловкий эльф и это мой прелестный прием:");
        base.TryUseSpecial();
    }
}
