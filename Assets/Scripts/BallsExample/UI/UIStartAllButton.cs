using UnityEngine.EventSystems;

public class UIStartAllButton : UIStartButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        _winController.SetStrategy(new AllBallsCountStrategy());
    }
}
