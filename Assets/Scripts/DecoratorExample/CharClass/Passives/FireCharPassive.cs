namespace Assets.Scripts.DecoratorExample
{
    public class FireCharPassive : CharStatsModifier
    {
        public FireCharPassive(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 5);

        public override Property Agility => AddStat(_initialStats.Agility, 0);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 4);
    }
}