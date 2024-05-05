namespace Assets.Scripts.DecoratorExample
{
    public class ThiefCharClass : CharStatsModifier
    {
        public ThiefCharClass(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 1);

        public override Property Agility => MultiplyStat(_initialStats.Agility, 2);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 3);
    }
}