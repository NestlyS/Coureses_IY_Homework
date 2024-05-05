using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.DecoratorExample
{
    public class PassiveToggler : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private CharPassiveTypes _passive;
        [SerializeField] private CharacterStatsMediator _mediator;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Выбрана пассивка " + _passive);
            _mediator.TogglePassive(_passive);
        }
    }
}