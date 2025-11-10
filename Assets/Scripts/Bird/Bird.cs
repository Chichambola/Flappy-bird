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
public class Bird : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdCollisonDetector _collisionDetector;
    private InputReader _inputReader;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionDetector = GetComponent<BirdCollisonDetector>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _collisionDetector.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionDetector.CollisionDetected -= ProcessCollision;
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

    private void ProcessCollision(IInteractable collision)
    {
        if (collision is Bullet || collision is Ground)
        {
            GameOver?.Invoke();
        }
    }
}
