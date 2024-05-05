using System;

namespace Assets.Scripts.DecoratorExample
{
    public class CharPassiveFactory : IStatsFactory<IStats, CharPassiveTypes>
    {
        public IStats Get(IStats stats, CharPassiveTypes type)
        {
            switch (type)
            {
                case CharPassiveTypes.Fire: return new FireCharPassive(stats);

                case CharPassiveTypes.Book: return new BookCharPassive(stats);

                case CharPassiveTypes.Wind: return new WindCharPassive(stats);

                default: throw new ArgumentException(nameof(type));
            }
        }
    }
}