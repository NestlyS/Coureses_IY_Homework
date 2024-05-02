using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    public class HealthData
    {
        public HealthData(int health) {
            Health = health;
        }
        [field: SerializeField] public int Health { get; private set; }

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }
    }
}