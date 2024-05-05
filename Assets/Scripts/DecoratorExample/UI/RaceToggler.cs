using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.DecoratorExample
{
    public class RaceToggler : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private CharRaceTypes _race;
        [SerializeField] private CharacterStatsMediator _mediator;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Выбрана раса " + _race);
            _mediator.ToggleRace(_race);
        }
    }
}