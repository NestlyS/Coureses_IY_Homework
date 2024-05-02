using UnityEngine;

[RequireComponent (typeof(CharacterController))]
[RequireComponent(typeof(WorkerViewMediator))]
public class WorkerController : MonoBehaviour, IMovable
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private WorkerViewMediator _viewMediator;

    [SerializeField] private Transform _chillPosition;
    [SerializeField] private Transform _workPosition;
    [SerializeField] private float _speed;

    private WorkerStateMachine _workerStateMachineSwitcher;
    private const float MinDistanseToTarget = 1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _viewMediator = GetComponent<WorkerViewMediator>();

        _workerStateMachineSwitcher = new WorkerStateMachine(this, _chillPosition, _workPosition);
        _viewMediator.Init(_workerStateMachineSwitcher);
    }

    private void OnDestroy()
    {
        _workerStateMachineSwitcher.Dispose();
    }

    private void Update()
    {
        _workerStateMachineSwitcher.Update();
    }

    public bool IsNearPoint(Vector3 point)
    {
        return (transform.position - point).magnitude <= MinDistanseToTarget;
    }

    public void MoveTo(Vector3 destination)
    {
        _characterController.Move(_speed * Time.deltaTime * (destination - transform.position));
    }

    public void TeleportTo(Vector3 destination)
    {
        transform.position = destination;
    }
}
