using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _scoreCounter.ValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _scoreCounter.ValueChanged -= UpdateValue;
    }

    private void UpdateValue(int value)
    {
        _text.text = $"{value}";
    }
}
