using UnityEngine;

public class MerchantBootstrap : MonoBehaviour
{
    [SerializeField] private TimeChanger _timeChanger;
    [SerializeField] private Merchant _merchant;
    [SerializeField] private InputController _controller;

    private INotifier _mediator;
    private MerchantTimeListener _listener;

    void Awake()
    {
        Debug.Log("����� ���� ������, ����� �������� �����. E ��� ��������������.");

        _listener = new MerchantTimeListener(_merchant);
        _mediator = new MerchantMediator(_listener);
        _timeChanger.Init(_mediator);
        _controller.Init(_merchant);
    }
}
