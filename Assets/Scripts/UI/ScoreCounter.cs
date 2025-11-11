using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    public event Action<int> ValueChanged;

    private int _resetNumber = 0;
    private int _score = 0;

    private void OnEnable()
    {
        _enemySpawner.EnemyHit += Add;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyHit -= Add;
    }

    public void Add()
    {
        _score++;

        ValueChanged?.Invoke(_score);
    }

    public void ResetValue()
    {
        _score = _resetNumber;

        ValueChanged?.Invoke(_score);
    }
}
