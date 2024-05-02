using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private int _enemyHealth;
        [SerializeField] private int _enemyReward;

        public Enemy Enemy {  get; private set; }

        public void Init()
        {
            if (Enemy != null) { 
                Destroy(Enemy.gameObject);
            }
        }

        public void Spawn()
        {
            Enemy = Instantiate(_enemyPrefab, transform);

            Enemy.transform.parent = transform;
            Enemy.Die += OnEnemyDie;

            Enemy.Init(_enemyHealth, _enemyReward);
        }

        private void OnEnemyDie(Enemy enemy)
        {
            Destroy(enemy.gameObject);
        }
    }
}