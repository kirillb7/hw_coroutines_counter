using System;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void Start()
    {
        _timerText.text = _timer.CurrentStep.ToString();
    }

    private void OnEnable()
    {
        _timer.Changed += ChangeDisplay;
    }

    private void OnDisable()
    {
        _timer.Changed -= ChangeDisplay;
    }

    private void ChangeDisplay(float value)
    {
        _timerText.text = value.ToString();
    }
}
