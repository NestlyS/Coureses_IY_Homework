using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Factory/Create Ork Factory")]
public class OrkFactory : CharacterFactory
{
    public override Character Get(ClassTypes type)
    {
        ISpecialStrategy specialStrategy;

        switch (type) {
            case ClassTypes.Mage: specialStrategy = new ShieldSpecial();
                break;

            case ClassTypes.Warrior: specialStrategy = new BerserkSpecial();
                break;

            default:
                throw new ArgumentException(nameof(type));
        }

        CharacterData character = new Ork(specialStrategy);
        Character instance = Instantiate(GetByType(type));
        instance.Init(character);

        return instance;
    }
}
