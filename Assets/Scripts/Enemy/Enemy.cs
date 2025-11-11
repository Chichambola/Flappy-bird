using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EnemyMover))]
public class Enemy : MonoBehaviour, IPoolable, IInteractable
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private CollisonDetector _collisionDetector;
    [SerializeField] private EdgeDetector _edgeDetector;

    public event Action<Enemy> OnBulletHit;

    private Coroutine _coroutine;
    private EnemyMover _mover;

    public void Init(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _collisionDetector.CollisionDetected += ProcessCollision;
        _edgeDetector.OffEdgeDetected += Rotate;
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
        _collisionDetector.CollisionDetected -= ProcessCollision;
        _edgeDetector.OffEdgeDetected -= Rotate;
    }

    private void Rotate()
    {
        _mover.ToggleDirection();
    }

    public void StartShooting()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    public void StartMoving()
    {
        _mover.StartMoving();
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_shootDelay);

        while(enabled)
        {
            _bulletSpawner.Shoot(_spawnPoint.transform.position, gameObject.transform.rotation);

            yield return wait;
        }
    }

    private void ProcessCollision(IInteractable collision)
    {
        if (collision is Bullet)
        {
            OnBulletHit?.Invoke(this);
        }
    }
}
