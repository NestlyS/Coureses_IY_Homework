using System;

namespace Assets.Scripts.MediatorExample
{
    public class Player
    {
        private PlayerDataPresets _levelPresets;
        private PlayerData _playerData;
        private PlayerView _playerView;
        private IDamagable _damageTarget;
        private int _level;
        public Player(PlayerDataPresets levelPresets, PlayerView playerView)
        {
            _levelPresets = levelPresets;
            _level = 1;
            UpdatePlayerData();
            _playerView = playerView;
        }

        public event Action<int> HpChange;
        public event Action<int> ExpChange;
        public event Action<int> LevelUpdate;
        public event Action<PlayerData> StatsChange;
        public event Action MaxLevelAchieved;
        public event Action Die;

        public void Init()
        {
            _playerView.Init();
            _playerView.TriggerReset();
            UpdatePlayerData();
        }

        public void GainExp(int amount)
        {
            if (_playerData.CurrentExp + amount >= _playerData.ExpToNextLevel)
            {
                LevelUp();
                return;
            }

            _playerData.GainExp(amount);
            ExpChange?.Invoke(_playerData.CurrentExp);
        }

        public void FightEnemy()
        {
            _damageTarget.TakeDamage(_playerData.Damage);
            HpChange?.Invoke(_playerData.Health);
            _playerView.TriggerAttack();
        }

        public void DrinkBeer()
        {
            TakeDamage(_levelPresets.BeerDamage);
            HpChange?.Invoke(_playerData.Health);
        }

        public void SetDamageTarget(IDamagable target)
        {
            _damageTarget = target;
        }

        private void TakeDamage(int amount)
        {
            _playerData.TakeDamage(amount);
            _playerView.TriggerDamage();

            if (_playerData.Health <= 0)
            {
                _playerView.TriggerDeath();
                _playerView.DeathFinished += OnDie;
            }
        }

        private void OnDie()
        {
            _playerView.DeathFinished -= OnDie;
            Die?.Invoke();
        }

        private void LevelUp()
        {
            if (_levelPresets.IsMaxLevel(_level))
            {
                MaxLevelAchieved?.Invoke();
                return;
            }

            _level++;
            _playerView.LevelUp();
            UpdatePlayerData();
        }

        private void UpdatePlayerData()
        {
            _playerData = new(_levelPresets.GetLevelPresetFor(_level));

            StatsChange?.Invoke(_playerData);
            LevelUpdate?.Invoke(_level);
        }
    }
}