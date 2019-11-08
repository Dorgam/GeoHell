using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] private float secondsBetweenBlinks;
    private IEnumerator _blinkCoroutine;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        
        if (_blinkCoroutine != null)
        {
            StopCoroutine(_blinkCoroutine);
        }

        _blinkCoroutine = Blink();
        StartCoroutine(_blinkCoroutine);
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            _text.alpha = 0;
            yield return new WaitForSeconds(secondsBetweenBlinks);
            _text.alpha = 1;
            yield return new WaitForSeconds(secondsBetweenBlinks);
        }
    }
}
