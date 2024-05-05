namespace Assets.Scripts.DecoratorExample
{
    public class WarriorCharClass : CharStatsModifier
    {
        public WarriorCharClass(IStats provider): base(provider)
        {
        }

        public override Property Strengh => MultiplyStat(_initialStats.Strengh, 2);

        public override Property Agility => AddStat(_initialStats.Agility, 2);

        public override Property Intellect =>  AddStat(_initialStats.Intellect, 1);
    }
}