using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private const int MIN_TIME = 0;
    private const int MAX_TIME = 60 * 60 * 24 - 1;

    public void Init()
    {
        OnUpdateValue(0);
    }
    public void OnUpdateValue(float value)
    {
        float time = Mathf.Lerp(MIN_TIME, MAX_TIME, value);
        double hours = Math.Floor(time / 60 / 60);
        int minutes = (int)(((time / 60 / 60) - hours) * 60);
        string hoursStr = hours <= 9 ? "0" + hours : hours.ToString();
        string minutesStr = minutes <= 9 ? "0" + minutes : minutes.ToString();
        _text.text = $"{hoursStr}:{minutesStr}";
    }
}
