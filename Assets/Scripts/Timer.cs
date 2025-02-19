using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay;

    private int _currentStep = 0;
    private bool _isCounting = false;

    public event Action<float> Changed;

    public int CurrentStep => _currentStep;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        if (_isCounting)
        {
            _isCounting = false;
            StopCoroutine(Count());
        }
        else
        {
            _isCounting = true;
            StartCoroutine(Count());
        }
    }

    private IEnumerator Count()
    {
        float elapsedTime = _currentStep * _delay;

        while (_isCounting)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime / _delay > _currentStep)
            {
                _currentStep++;

                Changed(_currentStep);
            }

            yield return null;
        }
    }
}
