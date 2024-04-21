using TMPro;
using UnityEngine;

public class UIBallCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _desc;
    [SerializeField] private TMP_Text _ballCounter;

    public void Init()
    {
        _ballCounter.text = "0";
        _ballCounter.enabled = false;
        _desc.enabled = false;
    }

    public void OnStart()
    {
        _ballCounter.enabled = true;
        _desc.enabled = true;
    }

    public void SetCount(int count)
    {
        _ballCounter.text = count.ToString();
    }
}
