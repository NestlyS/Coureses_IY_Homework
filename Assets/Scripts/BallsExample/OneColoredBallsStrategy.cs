public class OneColoredBallsStrategy : BallCountStrategy
{
    /**
     * � ������ ��� ����� ���� �� ���� �������� ���� ����
     *  "���� - �����", �� � �� ����, ��������� ��� ���������� � ����������� �������.
     * ��� ��� � ����� �������� ���.
     */
    private int redBallsCount = 0;
    private int greenBallsCount = 0;
    private int whiteBallsCount = 0;

    public override void AddBall(BallColors color)
    {
        switch (color)
        {
            case BallColors.White: whiteBallsCount++; break;
            case BallColors.Red: redBallsCount++; break;
            case BallColors.Green: greenBallsCount++; break;
        }
    }

    public override int CountBalls()
    {
        return GetSmallestCount();
    }

    public override void DeleteBall(BallColors color)
    {
        switch (color)
        {
            case BallColors.White: whiteBallsCount--; break;
            case BallColors.Red: redBallsCount--; break;
            case BallColors.Green: greenBallsCount--; break;
        }
    }

    private int GetSmallestCount()
    {
        int smallestCount = redBallsCount;

        if (greenBallsCount < smallestCount)
        {
            smallestCount = greenBallsCount;
        }

        if (whiteBallsCount < smallestCount)
        {
            smallestCount = whiteBallsCount;
        }

        return smallestCount;
    }
}
