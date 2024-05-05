using UnityEngine;

namespace Assets.Scripts.DecoratorExample
{
    public class CharacterStatsMediator : MonoBehaviour
    {
        [SerializeField] private StatsPanel _statsPanel;

        private CharacterStatsBuilder _characterStatsBuilder;

        public void Init(CharacterStatsBuilder characterStatsBuilder)
        {
            _characterStatsBuilder = characterStatsBuilder;
            _characterStatsBuilder.CharacterStatsChanged += OnCharacterStatsChanged;
        }

        public void ToggleRace(CharRaceTypes race)
        {
            _characterStatsBuilder.SetRace(race);
        }

        public void ToggleClass(CharClassTypes charClass)
        {
            _characterStatsBuilder.SetClass(charClass);
        }

        public void TogglePassive(CharPassiveTypes passive)
        {
            _characterStatsBuilder.SetPassive(passive);
        }

        private void OnCharacterStatsChanged(IStats stats)
        {
            Debug.Log(stats.Strengh.Value + " " + stats.Intellect.Value + " " + stats.Agility.Value);
            _statsPanel.SetStats(stats);
        }
    }
}