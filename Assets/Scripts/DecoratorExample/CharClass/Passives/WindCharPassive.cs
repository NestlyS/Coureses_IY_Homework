namespace Assets.Scripts.DecoratorExample
{
    public class WindCharPassive : CharStatsModifier
    {
        public WindCharPassive(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 2);

        public override Property Agility => AddStat(_initialStats.Agility, 8);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 1);
    }
}