using UnityEngine;

public class WorkerChillState : WorkerJobState
{
    public WorkerChillState(IWorkerStateMachineSwitcher switcher, Transform destination) : base(switcher, destination)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Отдыхаем");
    }

    public override void Exit()
    {
        base.Exit();
        Finish?.Invoke();
    }

    public override void Update()
    {
        base.Update();
    }
}
