using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay;

    private int _currentStep = 0;
    private bool _isCounting = false;

    public int CurrentStep => _currentStep;

    public event Action<float> Changed;

    public void Toggle()
    {
        if (_isCounting)
        {
            _isCounting = false;
        }
        else
        {
            _isCounting = true;
        }

        StartCoroutine(nameof(Count));
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
