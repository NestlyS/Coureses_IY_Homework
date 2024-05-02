using UnityEngine;

public class WorkerMoveState : WorkerState
{
    private IMovable _movable;
    private WorkerJobState _nextState;

    public WorkerMoveState(
        IWorkerStateMachineSwitcher switcher, 
        IMovable movable, 
        WorkerJobState nextState
        ) : base(switcher)
    {
        _movable = movable;
        _nextState = nextState;
    }

    public override void Enter()
    {
        Debug.Log("�����������");
    }

    public override void Exit()
    {
    }
    
    public override void Update()
    {
        if (_movable.IsNearPoint(_nextState.JobDestination.position))
        {
            /**
             * � �� ��������, ��� �������� ��� ���������� � �����.
             * */
            _switcher.SwitchState(_nextState);
            return;
        }

        _movable.MoveTo(_nextState.JobDestination.position);
    }

    public void SetNextState(WorkerJobState nextState)
    {
        _nextState = nextState;
    }
}
