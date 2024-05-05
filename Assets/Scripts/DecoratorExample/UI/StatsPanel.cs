using TMPro;
using UnityEngine;

namespace Assets.Scripts.DecoratorExample
{
    public class StatsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _strenghtText;
        [SerializeField] private TMP_Text _intellectText;
        [SerializeField] private TMP_Text _agilityText;

        public void SetStats(IStats stats)
        {
            _strenghtText.text = stats.Strengh.Value.ToString();
            _agilityText.text = stats.Agility.Value.ToString();
            _intellectText.text = stats.Intellect.Value.ToString();
        }
    }
}