using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(CollisonDetector))]
[RequireComponent(typeof(InputReader))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private SpawnPoint _spawnPoint;
    private BirdMover _mover;
    private CollisonDetector _collisionDetector;
    private InputReader _inputReader;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _collisionDetector = GetComponent<CollisonDetector>();
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
            _bulletSpawner.Shoot(_spawnPoint.transform.position, gameObject.transform.rotation);
        }
    }

    public void Reset()
    {
        _mover.Reset();
    }

    private void ProcessCollision(IInteractable collision)
    {
        if (collision is Bullet || collision is Ground)
        {
            GameOver?.Invoke();
        }
    }
}
