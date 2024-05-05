using UnityEngine;

namespace Assets.Scripts.DecoratorExample
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterStatsMediator _statsMediator;
        [SerializeField] private CharRaceTypes _defaultRace;
        [SerializeField] private CharClassTypes _defaultClass;
        [SerializeField] private CharPassiveTypes _defaultPassive;

        private CharacterStatsBuilder _characterStatsBuilder;

        private void Awake()
        {
            _characterStatsBuilder = new CharacterStatsBuilder();
            _statsMediator.Init(_characterStatsBuilder);
            _characterStatsBuilder.Init(
                _defaultRace, 
                _defaultClass, 
                _defaultPassive, 
                new CharStats(
                    new Property(1),
                    new Property(1),
                    new Property(1)
                )
            );
        }
    }
}