using UnityEngine;
using UnityEngine.EventSystems;

public class UIRestartButton : MonoBehaviour, IPointerClickHandler
{
    protected UIMediator _mediator;

    public void Init(UIMediator uiMediator)
    {
        _mediator = uiMediator;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        _mediator.TriggerStart();
    }
}
