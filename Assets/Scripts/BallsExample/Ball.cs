using UnityEngine;

public class Ball : MonoBehaviour
{
    private IBallListener _listener;
    private BallColors _color;
    
    public void Init (BallColors color, IBallListener listener)
    {
        _listener = listener;
        _color = color;
        listener.OnAwake(color);
    }

    private void OnMouseDown()
    {
        _listener.OnDestroy(_color);
        Destroy(gameObject);
    }
}
