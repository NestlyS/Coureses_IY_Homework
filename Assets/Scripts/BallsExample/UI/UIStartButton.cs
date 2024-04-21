using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIStartButton : MonoBehaviour, IPointerClickHandler
{
    protected UIMediator _mediator;
    protected WinController _winController;

    public void Init(UIMediator uiMediator, WinController winController)
    {
        _mediator = uiMediator;
        _winController = winController;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        _mediator.OnStart();
    }
}
