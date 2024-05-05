namespace Assets.Scripts.DecoratorExample
{
    public class MageCharClass : CharStatsModifier
    {
        public MageCharClass(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 0);

        public override Property Agility => AddStat(_initialStats.Agility, 2);

        public override Property Intellect => MultiplyStat(_initialStats.Intellect, 2);
    }
}