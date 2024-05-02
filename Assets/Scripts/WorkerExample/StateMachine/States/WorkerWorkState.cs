using UnityEngine;

public class WorkerWorkState : WorkerJobState
{
    public WorkerWorkState(IWorkerStateMachineSwitcher switcher, Transform destination) : base(switcher, destination)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Rock & Stone, brothers");
    }

    public override void Exit()
    {
        base.Exit();
        Finish?.Invoke();
    }

    public override void Update()
    {
        base .Update();
    }
}
