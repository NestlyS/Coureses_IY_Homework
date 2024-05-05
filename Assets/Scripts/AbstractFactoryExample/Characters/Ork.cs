using UnityEngine;

public class Ork : CharacterData
{
    public Ork(ISpecialStrategy specialStrategy) : base(specialStrategy)
    {

    }

    public override void TryUseSpecial()
    {
        Debug.Log("� ������� ��� � ��� ��� ������ �����:");
        base.TryUseSpecial();
    }
}
