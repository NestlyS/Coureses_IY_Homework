using UnityEngine;

public class BallMediator : IBallListener
{
    [SerializeField] private WinController _controller;

    public BallMediator(WinController controller)
    {
        _controller = controller;
    }

    public void OnAwake(BallColors color)
    {
        _controller.OnBallAdd(color);
    }

    public void OnDestroy(BallColors color)
    {
        _controller.OnBallDelete(color);
    }
}
