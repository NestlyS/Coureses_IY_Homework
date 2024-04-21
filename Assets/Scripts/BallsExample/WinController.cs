public class WinController
{
    private BallCountStrategy _strategy;
    private UIMediator _uiMediator;

    public WinController(BallCountStrategy strategy, UIMediator uIMediator)
    {
        _strategy = strategy;
        _uiMediator = uIMediator;
    }

    public void SetStrategy(BallCountStrategy strategy)
    {
        _strategy = strategy;
    }

    public void OnBallAdd(BallColors colors)
    {
        _strategy.AddBall(colors);
        _uiMediator.UpdateBallCounter(_strategy.CountBalls());
    }

    public void OnBallDelete(BallColors colors)
    {
        _strategy.DeleteBall(colors);
        _uiMediator.UpdateBallCounter(_strategy.CountBalls());
        if (_strategy.CountBalls() <= 0)
        {
            _uiMediator.TriggerWin();
        }
    }
}
