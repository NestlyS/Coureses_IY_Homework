using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Factory/Create Elf Factory")]
public class ElfFactory : CharacterFactory
{
    public override Character Get(ClassTypes type)
    {
        ISpecialStrategy specialStrategy;

        switch (type) {
            case ClassTypes.Mage: specialStrategy = new NatureSpecial();
                break;

            case ClassTypes.Warrior: specialStrategy = new AssasinSpecial();
                break;

            default:
                throw new ArgumentException(nameof(type));
        }

        CharacterData character = new Elf(specialStrategy);
        Character instance = Instantiate(GetByType(type));
        instance.Init(character);

        return instance;
    }
}
