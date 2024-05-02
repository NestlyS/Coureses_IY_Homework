using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MediatorExample
{
    [RequireComponent(typeof(Animator))]
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private Animator _animator;

        private const string Appear = "Appear";
        private const string Damage = "Damage";
        private const string Die = "Die";

        public event Action DeathFinished;

        public void Init(int maxHealth)
        {
            _animator = GetComponent<Animator>();
            _hpSlider.maxValue = maxHealth;
            _hpSlider.value = maxHealth;
        }

        public void UpdateHp(int amount)
        {
            _hpSlider.value = amount;
        }

        public void TriggerAppear() => _animator.SetTrigger(Appear);
        public void TriggerDamage() => _animator.SetTrigger(Damage);
        public void TriggerDeath() => _animator.SetTrigger(Die);
        public void TriggerDeathFinished() => DeathFinished?.Invoke();
    }
}