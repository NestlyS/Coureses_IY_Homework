using System.Collections.Generic;

public class UIMediator
{
    private UIBallCounter _ballCounter;
    private UICanvasController _winCanvas;
    private UICanvasController _gameCanvas;
    private UICanvasController _startCanvas;
    private List<BallSpawner> _spawners;

    public UIMediator(
        UIBallCounter ballCounter, 
        UICanvasController winCanvas,
        UICanvasController gameCanvas,
        UICanvasController startCanvas,
        List<BallSpawner> spawners
    )
    {
        _ballCounter = ballCounter;
        _winCanvas = winCanvas;
        _gameCanvas = gameCanvas;
        _startCanvas = startCanvas;
        _spawners = new List<BallSpawner>(spawners);
    }

    public void UpdateBallCounter(int count)
    {
        _ballCounter.SetCount(count);
    }

    public void TriggerWin()
    {
        _winCanvas.OnTrigger(Screens.Win);
        _gameCanvas.OnTrigger(Screens.Win);
        _startCanvas.OnTrigger(Screens.Win);
    }

    public void TriggerStart()
    {
        _winCanvas.OnTrigger(Screens.Start);
        _gameCanvas.OnTrigger(Screens.Start);
        _startCanvas.OnTrigger(Screens.Start);
        _spawners.ForEach(spawner => spawner.Clear());
    }

    public void TriggerGame()
    {
        _winCanvas.OnTrigger(Screens.Game);
        _gameCanvas.OnTrigger(Screens.Game);
        _startCanvas.OnTrigger(Screens.Game);
    }

    public void OnStart()
    {
        _spawners.ForEach(spawner => spawner.Spawn());
        _ballCounter.OnStart();
        TriggerGame();
    }
}
