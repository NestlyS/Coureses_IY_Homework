using UnityEngine;

public class AbstractFactoryBootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _firstSpawner;
    [SerializeField] private Spawner _secondSpawner;
    [SerializeField] private CoinSpawner _coinSpawner;

    [SerializeField] private OrkFactory _orkFactory;
    [SerializeField] private ElfFactory _elfFactory;
    [SerializeField] private CoinFactory _coinFactory;

    private IFactory _adaptedFirstSpawnerFactory;
    private IFactory _adaptedSecondSpawnerFactory;

    private void Awake()
    {
        _adaptedFirstSpawnerFactory = new RandomClassCharacterFactoryAdapter(_orkFactory);
        _adaptedSecondSpawnerFactory = new RandomClassCharacterFactoryAdapter(_elfFactory);

        _firstSpawner.Init(_adaptedFirstSpawnerFactory);
        _secondSpawner.Init(_adaptedSecondSpawnerFactory);
        _coinSpawner.Init(_coinFactory);

        _firstSpawner.StartSpawn();
        _secondSpawner.StartSpawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IFactory temp = _adaptedFirstSpawnerFactory;
            _adaptedFirstSpawnerFactory = _adaptedSecondSpawnerFactory;
            _adaptedSecondSpawnerFactory = temp;

            _firstSpawner.SetFactory( _adaptedFirstSpawnerFactory);
            _secondSpawner.SetFactory(_adaptedSecondSpawnerFactory);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_firstSpawner.IsSpawning)
            {
                _firstSpawner.StopSpawn();
            } else
            {
                _firstSpawner.StartSpawn();
            }

            if (_secondSpawner.IsSpawning)
            {
                _secondSpawner.StopSpawn();
            }
            else
            {
                _secondSpawner.StartSpawn();
            }
        }

        if ( Input.GetKeyDown(KeyCode.F))
        {
            _coinSpawner.SpawnOne();
        }
    }
}
