using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(BirdMover), typeof(BirdCollisonDetector), typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdCollisonDetector _collisonDetector;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisonDetector = GetComponent<BirdCollisonDetector>();
    }

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
    }
}
