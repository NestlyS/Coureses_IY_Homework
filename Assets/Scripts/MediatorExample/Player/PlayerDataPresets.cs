using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    [CreateAssetMenu(menuName = "LevelPresets")]
    public class PlayerDataPresets : ScriptableObject
    {
        [SerializeField] private int _beerDamage;
        [SerializeField] private List<PlayerData> _levelPresets;

        public int BeerDamage { get => _beerDamage; private set => _beerDamage = value; }

        public PlayerData GetLevelPresetFor(int level)
        {
            if (level > _levelPresets.Count - 1)
            {
                return _levelPresets[_levelPresets.Count - 1];
            }

            return _levelPresets[level];
        }

        public bool IsMaxLevel(int level) => level >= _levelPresets.Count - 1;
    }
}