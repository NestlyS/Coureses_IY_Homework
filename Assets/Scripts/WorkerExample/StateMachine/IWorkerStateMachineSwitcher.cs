public interface IWorkerStateMachineSwitcher
{
    public void SwitchState<T>() where T : WorkerState;
    public void SwitchState(WorkerState workerState);
}
