namespace Assets.Scripts.DecoratorExample
{
    public class BookCharPassive : CharStatsModifier
    {
        public BookCharPassive(IStats provider): base(provider)
        {
        }

        public override Property Strengh => AddStat(_initialStats.Strengh, 0);

        public override Property Agility => AddStat(_initialStats.Agility, 1);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 8);
    }
}