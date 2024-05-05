using UnityEngine;

namespace Assets.Scripts.DecoratorExample
{
    public abstract class CharStatsModifier : IStats
    {
        protected readonly IStats _initialStats;

        public CharStatsModifier(IStats stats)
        {
            _initialStats = stats;
        }

        public abstract Property Strengh { get; }

        public abstract Property Agility {  get; }

        public abstract Property Intellect { get; }

        public static Property AddStat(Property stat, int amount) => new(stat.Value + amount);
        public static Property MultiplyStat(Property stat, int amount) => new(stat.Value * amount);
    }
}