using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Transform[] _spawnPoints;

    public event Action EnemyHit;

    private Coroutine _coroutine;
    private Vector3 _spawnPointPosition;

    private void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawn());
    }

    public override void ReleaseAll()
    {
        if (ActiveObjects.Count != 0)
        {
            foreach (Enemy enemy in ActiveObjects.ToList())
            {
                enemy.OnBulletHit -= Release;

                Release(enemy);
            }

            ActiveObjects.Clear();
        }
    }

    protected override void ActionOnGet(Enemy enemy)
    {
        enemy.Init(_bulletSpawner);

        enemy.transform.position = _spawnPointPosition;

        enemy.transform.parent = transform.parent;

        base.ActionOnGet(enemy);

        enemy.OnBulletHit += Release;

        enemy.StartMoving();

        enemy.StartShooting();

        ActiveObjects.Add(enemy);
    }

    protected override void ActionOnRelease(Enemy enemy)
    {
        ActiveObjects.Remove(enemy);

        EnemyHit?.Invoke();

        base.ActionOnRelease(enemy);

        enemy.OnBulletHit -= Release;
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            _spawnPointPosition = _spawnPoints[GetRandonIndex()].position;

            GetObject();
        }
    }

    private int GetRandonIndex()
    {
        int firstIndex = 0;

        return Random.Range(firstIndex, _spawnPoints.Length);
    }
}
