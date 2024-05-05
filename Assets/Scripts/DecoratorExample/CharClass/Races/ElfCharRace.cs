namespace Assets.Scripts.DecoratorExample
{
    public class ElfCharRace : CharStatsModifier
    {
        public ElfCharRace(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 1);

        public override Property Agility => AddStat(_initialStats.Agility, 7);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 4);
    }
}