using System;
using UnityEngine;

public class WorkerJobState : WorkerState
{
    public Action Finish;

    public Transform JobDestination {  get; private set; }

    private float _timerInState = 1;
    private float _currentTimer = 0;

    public WorkerJobState(IWorkerStateMachineSwitcher switcher, Transform jobDestination) : base(switcher)
    {
        JobDestination = jobDestination;
    }

    public override void Enter()
    {
        _currentTimer = _timerInState;
    }

    public override void Exit()
    {
        Finish?.Invoke();
    }

    public override void Update()
    {
        if (_currentTimer < 0)
        {
            _switcher.SwitchState<WorkerMoveState>();
            return;
        }

        _currentTimer -= Time.deltaTime;

        InvokeTimerChange(_timerInState - _currentTimer);
    }
}
