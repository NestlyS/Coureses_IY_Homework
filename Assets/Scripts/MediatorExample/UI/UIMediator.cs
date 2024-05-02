using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    public class UIMediator: MonoBehaviour
    {
        private MainScreen _mainScreen;
        private GameOverScreen _gameOverScreen;
        private Level _level;

        private void OnDestroy()
        {
            ResetAllPlayerListeners(_level.Player);

            _mainScreen.BeerButtonClick -= OnBeerButtonClick;
            _mainScreen.FightButtonClick -= OnFightButtonClick;

            _gameOverScreen.Restart -= OnRestart;
        }

        public void Init(Level level, MainScreen canvas, GameOverScreen gameOverScreen)
        {
            _mainScreen = canvas;
            _gameOverScreen = gameOverScreen;
            _level = level;

            InitGameLogic();

            _mainScreen.BeerButtonClick += OnBeerButtonClick;
            _mainScreen.FightButtonClick += OnFightButtonClick;

            _gameOverScreen.Restart += OnRestart;
            _gameOverScreen.gameObject.SetActive(false);
        }
        private void SetAllPlayerListeners(Player player)
        {
            player.ExpChange += OnExpChange;
            player.HpChange += OnHpChange;
            player.StatsChange += OnStatsChange;
            player.LevelUpdate += OnNextLevel;
            player.MaxLevelAchieved += OnMaxLevelAchieved;
            player.Die += OnPlayerDie;
        }

        private void ResetAllPlayerListeners(Player player)
        {
            player.ExpChange -= OnExpChange;
            player.HpChange -= OnHpChange;
            player.StatsChange -= OnStatsChange;
            player.LevelUpdate -= OnNextLevel;
            player.MaxLevelAchieved -= OnMaxLevelAchieved;
            player.Die -= OnPlayerDie;
        }

        private void OnRestart()
        {
            ResetAllPlayerListeners(_level.Player);

            _mainScreen.gameObject.SetActive(true);
            _gameOverScreen.gameObject.SetActive(false);

            InitGameLogic();
        }

        private void InitGameLogic()
        {
            _level.Init();
            SetAllPlayerListeners(_level.Player);
            _level.Player.Init();
        }

        private void OnPlayerDie()
        {
            _mainScreen.gameObject.SetActive(false);
            _gameOverScreen.gameObject.SetActive(true);
        }

        private void OnFightButtonClick()
        {
            _level.Player.FightEnemy();
        }

        private void OnBeerButtonClick()
        {
            _level.Player.DrinkBeer();
        }

        private void OnStatsChange(PlayerData data)
        {
            _mainScreen.SetMaxValues(data.Health, data.ExpToNextLevel);
            OnExpChange(data.CurrentExp);
            OnHpChange(data.Health);
        }

        private void OnNextLevel(int level)
        {
            _mainScreen.UpdateLevel(level);
            if (level != 1) _mainScreen.ShowLevelUpMessage();
        }

        private void OnMaxLevelAchieved()
        {
            _mainScreen.SetMaxLevel();
        }

        private void OnHpChange(int amount)
        {
            _mainScreen.UpdateHp(amount);
        }

        private void OnExpChange(int amount)
        {
            _mainScreen.UpdateExp(amount);
        }
    }
}