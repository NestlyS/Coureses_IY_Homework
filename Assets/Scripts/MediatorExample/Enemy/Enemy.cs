using System;
using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        [SerializeField] private EnemyView _enemyView = null;
        private HealthData _healthData;
        private bool _isDead = false;

        public event Action<Enemy> Die;

        public int ExpReward {  get; private set; }

        public void Init(int health, int expReward)
        {
            _healthData = new HealthData(health);
            _enemyView.Init(health);
            _isDead = false;

            ExpReward = expReward;
        }

        public void TakeDamage(int amount)
        {
            if (_isDead) return;

            _healthData.TakeDamage(amount);
            _enemyView.UpdateHp(_healthData.Health);
            _enemyView.TriggerDamage();

            if (_healthData.Health <= 0)
            {
                _isDead = true;
                _enemyView.TriggerDeath();
                _enemyView.DeathFinished += OnDeathFinished;
            }
        }

        private void OnDeathFinished()
        {
            _enemyView.DeathFinished -= OnDeathFinished;
            Die?.Invoke(this);
        }
    }
}