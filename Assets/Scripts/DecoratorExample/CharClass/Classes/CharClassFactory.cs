using System;

namespace Assets.Scripts.DecoratorExample
{
    public class CharClassFactory : IStatsFactory<IStats, CharClassTypes>
    {
        public IStats Get(IStats stats, CharClassTypes type)
        {
            switch (type)
            {
                case CharClassTypes.Thief: return new ThiefCharClass(stats);

                case CharClassTypes.Mage: return new MageCharClass(stats);

                case CharClassTypes.Warrior: return new WarriorCharClass(stats);

                default: throw new ArgumentException(nameof(type));
            }
        }
    }
}