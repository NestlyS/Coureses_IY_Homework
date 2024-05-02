using System;

public class WorkerStateMediator: IDisposable
{
    private WorkerChillState _chillState;
    private WorkerWorkState _workState;
    private WorkerMoveState _moveState;

    public WorkerStateMediator(WorkerChillState workerChillState, WorkerWorkState workerWorkState, WorkerMoveState moveState)
    {
        _chillState = workerChillState;
        _workState = workerWorkState;
        _moveState = moveState;

        _chillState.Finish += OnChillFinish;
        _workState.Finish += OnWorkFinish;
    }

    public void Dispose()
    {
        _chillState.Finish -= OnChillFinish;
        _workState.Finish -= OnWorkFinish;
    }

    private void OnWorkFinish()
    {
        _moveState.SetNextState(_chillState);
    }

    private void OnChillFinish()
    {
        _moveState.SetNextState(_workState);
    }
}
