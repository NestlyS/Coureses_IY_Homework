using System;

public abstract class WorkerState
{
    protected IWorkerStateMachineSwitcher _switcher;

    public WorkerState(IWorkerStateMachineSwitcher switcher)
    {
        _switcher = switcher;
    }

    public event Action<float> TimerChange;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();

    protected void InvokeTimerChange(float time)
    {
        TimerChange?.Invoke(time);
    }
}
