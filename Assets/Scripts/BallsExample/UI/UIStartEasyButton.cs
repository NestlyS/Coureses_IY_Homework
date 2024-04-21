using UnityEngine.EventSystems;

public class UIStartEasyButton : UIStartButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        _winController.SetStrategy(new OneColoredBallsStrategy());
    }
}
