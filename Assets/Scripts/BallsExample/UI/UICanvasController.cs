using UnityEngine;
using UnityEngine.Device;

public enum Screens
{
    Start,
    Game,
    Win
}

public abstract class UICanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _childContainer;
    protected Screens _screen;

    protected virtual void Init(Screens screen)
    {
        _childContainer.SetActive(false);
        _screen = screen;
    }

    public void OnTrigger(Screens screen)
    {
        if (screen == _screen)
        {
            SetChildEnabled(true);
            return;
        }

        SetChildEnabled(false);
    }

    protected void SetChildEnabled(bool enabled)
    {
        _childContainer.SetActive(enabled);
    }
}
