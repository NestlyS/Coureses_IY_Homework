using UnityEngine;

public class Elf : CharacterData
{
    public Elf(ISpecialStrategy specialStrategy) : base(specialStrategy)
    {

    }

    public override void TryUseSpecial()
    {
        Debug.Log("� ������ ���� � ��� ��� ���������� �����:");
        base.TryUseSpecial();
    }
}
