using System.Collections.Generic;
using UnityEngine;

public class BallsBootstrap : MonoBehaviour
{
    [SerializeField] ColorsToMaterialMap _colorMap;

    [SerializeField] List<BallSpawner> _spawners;
    [SerializeField] UIBallCounter _uiCounter;

    [SerializeField] UIWinCanvasController _uiWinCanvas;
    [SerializeField] UIStartCanvasController _uiStartCanvas;
    [SerializeField] UIGameCanvasController _uiGameCanvas;

    [SerializeField] UIStartButton _startEasyButton;
    [SerializeField] UIStartButton _startAllButton;
    [SerializeField] UIRestartButton _restartButton;

    private void Awake()
    {
        _colorMap.Init();
        _uiCounter.Init();
        _uiWinCanvas.Init();
        _uiStartCanvas.Init();
        _uiGameCanvas.Init();

        UIMediator uIMediator = new(_uiCounter, _uiWinCanvas, _uiGameCanvas, _uiStartCanvas, _spawners);

        BallCountStrategy oneCountStrategy = new OneColoredBallsStrategy();
        WinController winController = new(oneCountStrategy, uIMediator);

        _startEasyButton.Init(uIMediator, winController);
        _startAllButton.Init(uIMediator, winController);
        _restartButton.Init(uIMediator);

        IBallListener listener = new BallMediator(winController);
        _spawners.ForEach(spawner => spawner.Init(listener));
    }
}
