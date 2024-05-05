using System;

namespace Assets.Scripts.DecoratorExample
{
    public class CharacterStatsBuilder : ICharStatsProvider
    {
        private IStats _initialStats;
        private CharClassTypes _class;
        private CharRaceTypes _race;
        private CharPassiveTypes _passive;

        private CharClassFactory _classFactory;
        private CharRaceFactory _raceFactory;
        private CharPassiveFactory _passiveFactory;

        public CharacterStatsBuilder() { 
            _classFactory = new CharClassFactory();
            _raceFactory = new CharRaceFactory();
            _passiveFactory = new CharPassiveFactory();
        }

        public event Action<IStats> CharacterStatsChanged;

        public IStats CharStats { get; private set; }

        public void Init(CharRaceTypes race, CharClassTypes charClass, CharPassiveTypes passive, IStats stats)
        {
            _class = charClass;
            _race = race;
            _passive = passive;
            _initialStats = stats;

            Rebuild();
        }

        public void SetClass(CharClassTypes classType)
        {
            _class = classType;
            Rebuild();
        }

        public void SetRace(CharRaceTypes race)
        {
            _race = race;
            Rebuild();
        }

        public void SetPassive(CharPassiveTypes passive)
        {
            _passive = passive;
            Rebuild();
        }

        private void Rebuild()
        {
            CharStats = _passiveFactory.Get(
                _classFactory.Get(
                    _raceFactory.Get(
                            _initialStats,
                            _race
                        ),
                    _class
                ),
                _passive
            );
            CharacterStatsChanged?.Invoke(CharStats);
        }
    }
}