using System;
using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    [Serializable]
    public class PlayerData: HealthData
    {
        public PlayerData(PlayerData data): base(data.Health)
        {
            ExpToNextLevel = data.ExpToNextLevel;
            Damage = data.Damage;
        }

        [field: SerializeField] public int ExpToNextLevel { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        public int CurrentExp { get; private set; }

        public void GainExp(int amount) {
            CurrentExp += amount;
        }
    }
}