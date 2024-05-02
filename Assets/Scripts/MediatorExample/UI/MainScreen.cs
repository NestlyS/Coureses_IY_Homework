using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MediatorExample
{
    public class MainScreen : MonoBehaviour
    {
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private Slider _expSlider;
        [SerializeField] private TMP_Text _levelCount;
        [SerializeField] private TMP_Text _levelUpMessage;
        [SerializeField] private Button _fightButton;
        [SerializeField] private Button _beerButton;
        [SerializeField] private float _levelUpShowUpTime;

        public event Action FightButtonClick;
        public event Action BeerButtonClick;

        public void Init()
        {
            _hpSlider.value = 1;
            _hpSlider.maxValue = 1;
            _expSlider.value = 1;
            _expSlider.maxValue = 1;
            _levelCount.text = "0";
            _levelUpMessage.gameObject.SetActive(false);
        }

        public void OnBeerButtonClick()
        {
            BeerButtonClick?.Invoke();
        }

        public void OnFightButtonClick()
        {
            FightButtonClick?.Invoke();
        }

        public void SetMaxValues(int health, int exp)
        {
            _hpSlider.maxValue = health;
            _expSlider.maxValue = exp;
            _hpSlider.value = health;
            _expSlider.value = exp;
        }

        public void UpdateHp(int hp)
        {
            _hpSlider.value = hp;
        }

        public void UpdateExp(int exp)
        {
            _expSlider.value = exp;
        }

        public void UpdateLevel(int level)
        {
            _levelCount.text = level.ToString();
        }

        public void ShowLevelUpMessage()
        {
            StartCoroutine(ShowLevelUpMessageAsync());
        }

        public void SetMaxLevel()
        {
            _levelCount.text = "MAX";
            _expSlider.value = _expSlider.maxValue;
        }

        IEnumerator ShowLevelUpMessageAsync()
        {
            _levelUpMessage.gameObject.SetActive(true);
            yield return new WaitForSeconds(_levelUpShowUpTime);
            _levelUpMessage.gameObject.SetActive(false);
        }
        
    }
}