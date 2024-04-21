using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _dot;
    [SerializeField] private Image _fillArea;
    [SerializeField] private RectTransform _background;
    [SerializeField] private TimeShower _shower;

    [SerializeField] private Gradient _color;

    private INotifier _notifier;
    private const int FROM_LIN_TO_RAD = 6;

    public void Init(INotifier notifier)
    {
        _notifier = notifier;
        _slider = GetComponent<Slider>();
        _background = GetComponent<RectTransform>();
        _shower.Init();
        OnValueChanged();
    }

    public void OnValueChanged()
    {
        _notifier.Notify(_slider.value);

        float fixedValue = (_slider.value * FROM_LIN_TO_RAD) - FROM_LIN_TO_RAD / 2 ;
        double x = Math.Sin(fixedValue) * (_background.sizeDelta.x / 2);
        double y = Math.Cos(fixedValue) * (_background.sizeDelta.y / 2);
        _dot.rectTransform.anchoredPosition = new Vector2((float)x, (float)y);

        _fillArea.color = _color.Evaluate(_slider.value);
        _dot.color = _color.Evaluate(_slider.value);
        _shower.OnUpdateValue(_slider.value);
    }
}
