using System;
using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    [RequireComponent(typeof(Animator))]
    public class PlayerView : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _player;
        [SerializeField] private float _levelUpScaleAmount;

        private const string Attack = "Attack";
        private const string Damage = "Damage";
        private const string Die = "Die";
        private const string Reset = "Reset";

        public event Action DeathFinished;

        public void Init()
        {
            _animator = GetComponent<Animator>();
            _player.localScale = Vector3.one;
        }

        public void LevelUp()
        {
            _player.localScale *= _levelUpScaleAmount;
        }

        public void TriggerAttack() => _animator.SetTrigger(Attack);
        public void TriggerDamage() => _animator.SetTrigger(Damage);
        public void TriggerDeath() => _animator.SetTrigger(Die);
        public void TriggerReset() => _animator.SetTrigger(Reset);
        public void TriggerDeathFinished() => DeathFinished?.Invoke();
    }
}