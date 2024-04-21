public class MerchantMediator : INotifier
{
    private ITimeListener _listener;

    public MerchantMediator(ITimeListener listener)
    {
        _listener = listener;
    }

    public void Notify(float val)
    {
        _listener.onTimeUpdate(val);
    }
}
