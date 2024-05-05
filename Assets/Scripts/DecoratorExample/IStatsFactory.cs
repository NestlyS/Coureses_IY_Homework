namespace Assets.Scripts.DecoratorExample
{
    public interface IStatsFactory<ReturnType, GetType>
    {
        public ReturnType Get(IStats stats, GetType type);
    }
}