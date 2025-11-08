using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdCollisonDetector))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Gun))]
public class Bird : MonoBehaviour
{
    private Gun _gun;
    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdCollisonDetector _collisonDetector;
    private InputReader _inputReader;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisonDetector = GetComponent<BirdCollisonDetector>();
        _inputReader = GetComponent<InputReader>();
        _gun = GetComponent<Gun>();
    }

    private void OnEnable()
    {
        _collisonDetector.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisonDetector.CollisionDetected -= ProcessCollision;
    }

    private void FixedUpdate()
    {
        if (_inputReader.GetIsJump())
        {
            _mover.Move();
        }

        if (_inputReader.GetIsFiring())
        {
            _gun.Shoot();
        }
    }

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        
    }
}
