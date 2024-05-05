namespace Assets.Scripts.DecoratorExample
{
    public class CharStats: IStats
    {
        public CharStats(Property strengh, Property agility, Property intellect)
        {
            Strengh = strengh;
            Agility = agility;
            Intellect = intellect;
        }

        public Property Strengh
        {
            get;
            private set;
        }

        public Property Agility
        {
            get;
            private set;
        }

        public Property Intellect
        {
            get;
            private set;
        }

    }
}