using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkerStateMachine: TimeListener, IWorkerStateMachineSwitcher, IDisposable
{
    private readonly Transform _moveChillPosition;
    private readonly Transform _moveWorkPosition;
    private readonly List<WorkerState> _workerStates;
    private readonly WorkerStateMediator _stateMediator;
    private WorkerState _currentState;

    public WorkerStateMachine(IMovable movable, Transform chillPosition, Transform workPosition)
    {
        _moveChillPosition = chillPosition;
        _moveWorkPosition = workPosition;

        WorkerChillState chillState = new(this, _moveChillPosition);
        WorkerWorkState workState = new(this, _moveWorkPosition);
        WorkerMoveState moveState = new(this, movable, workState);

        chillState.TimerChange += OnTimerChange;
        workState.TimerChange += OnTimerChange;

        _stateMediator = new WorkerStateMediator(chillState, workState, moveState);

        _workerStates = new List<WorkerState>()
        {
            chillState,
            moveState,
            workState,
        };

        _currentState = _workerStates[0];
        _currentState.Enter();
    }

    public void Dispose()
    {
        _workerStates.ForEach(state =>
        {
            if (state is WorkerJobState)
            {
                state.TimerChange -= OnTimerChange;
            }
        });

        _stateMediator.Dispose();
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void SwitchState<T>() where T : WorkerState
    {
        WorkerState state = _workerStates.FirstOrDefault(state => state is T);

        SwitchStateTo(state);
    }

    public void SwitchState(WorkerState workerState)
    {
        SwitchStateTo(workerState);
    }

    private void OnTimerChange(float time)
    {
        TimerChange?.Invoke(time);
    }

    private void SwitchStateTo(WorkerState workerState)
    {
        _currentState.Exit();
        _currentState = workerState;
        _currentState.Enter();
    }
}
