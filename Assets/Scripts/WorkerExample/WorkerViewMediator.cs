using UnityEngine;
using UnityEngine.UI;

public class WorkerViewMediator : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;

    private TimeListener _stateMachine;

    public void Init(TimeListener workerStateMachine)
    {
        _stateMachine = workerStateMachine;
        _stateMachine.TimerChange += OnTimerChange;
    }

    private void OnTimerChange(float timer)
    {
        _progressBar.value = timer;
    }
}
