using UnityEngine;

public abstract class CharacterData
{
    public CharacterData(ISpecialStrategy specialStrategy)
    {
        SpecialStrategy = specialStrategy;
    }

    public CharacterData() {}

    public ISpecialStrategy SpecialStrategy { get; protected set; }

    public virtual void TryUseSpecial()
    {
        if (SpecialStrategy != null)
        {
            SpecialStrategy.UseSpecial();
            return;
        }

        Debug.Log("У меня нет спешиала :с");
    }
}
