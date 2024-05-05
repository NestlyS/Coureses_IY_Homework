namespace Assets.Scripts.DecoratorExample
{
    public class OrkCharRace : CharStatsModifier
    {
        public OrkCharRace(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 6);

        public override Property Agility => AddStat(_initialStats.Agility, 4);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 0);
    }
}