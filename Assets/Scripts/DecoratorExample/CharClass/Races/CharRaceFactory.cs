using System;

namespace Assets.Scripts.DecoratorExample
{
    public class CharRaceFactory : IStatsFactory<IStats, CharRaceTypes>
    {
        public IStats Get(IStats stats, CharRaceTypes type)
        {
            switch (type)
            {
                case CharRaceTypes.Ork: return new OrkCharRace(stats);

                case CharRaceTypes.Elf: return new ElfCharRace(stats);

                case CharRaceTypes.Human: return new HumanCharRace(stats);

                default: throw new ArgumentException(nameof(type));
            }
        }
    }
}