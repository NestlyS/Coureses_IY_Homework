public class AllBallsCountStrategy : BallCountStrategy
{
    private int _ballCount; 

    public override void AddBall(BallColors color)
    {
        _ballCount++;
    }

    public override void DeleteBall(BallColors color)
    {
        _ballCount--;
    }

    public override int CountBalls()
    {
        return _ballCount;
    }
}
