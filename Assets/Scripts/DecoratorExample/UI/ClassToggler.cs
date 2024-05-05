using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.DecoratorExample
{
    public class ClassToggler : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private CharClassTypes _class;
        [SerializeField] private CharacterStatsMediator _mediator;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Выбран класс" + _class);
            _mediator.ToggleClass(_class);
        }
    }
}