using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private EnemyController _enemySpawner;
        [SerializeField] private PlayerDataPresets _presets;
        [SerializeField] private PlayerView _playerView;

        public Player Player {  get; private set; }

        public void Init()
        {
            _enemySpawner.Init();

            Player = new(_presets, _playerView);
            SpawnEnemy();
        }

        public void SpawnEnemy()
        {
            _enemySpawner.Spawn();
            _enemySpawner.Enemy.Die += OnEnemyDie;

            Player.SetDamageTarget(_enemySpawner.Enemy);
        }

        private void OnEnemyDie(Enemy enemy)
        {
            _enemySpawner.Enemy.Die -= OnEnemyDie;
            Player.GainExp(enemy.ExpReward);

            SpawnEnemy();
        }
    }
}