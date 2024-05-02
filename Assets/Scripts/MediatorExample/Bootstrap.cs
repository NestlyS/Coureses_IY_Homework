using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private MainScreen _mainScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private UIMediator _mediator;
        [SerializeField] private Level _level;

        private void Awake()
        {
            _mainScreen.Init();
            _level.Init();
            _mediator.Init(_level, _mainScreen, _gameOverScreen);
        }
    }
}

