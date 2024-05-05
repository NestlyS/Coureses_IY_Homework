namespace Assets.Scripts.DecoratorExample
{
    public class HumanCharRace : CharStatsModifier
    {
        public HumanCharRace(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 5);

        public override Property Agility => AddStat(_initialStats.Agility, 5);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 5);
    }
}