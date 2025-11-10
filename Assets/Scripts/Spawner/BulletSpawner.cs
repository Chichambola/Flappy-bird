using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Action = UnityEngine.Events.UnityAction;


public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private SpawnPoint _spawnPoint;

    public void GetBullet()
    {
        GetObject();
    }
    
    protected override void ActionOnGet(Bullet bullet)
    {
        bullet.transform.position = _spawnPoint.transform.position;

        bullet.transform.rotation = gameObject.transform.rotation;

        Debug.Log(bullet.transform.position);

        base.ActionOnGet(bullet);

        bullet.IsHit += Release;
    }

    protected override void ActionOnRelease(Bullet bullet)
    {
        base.ActionOnRelease(bullet);

        bullet.IsHit -= Release;
    }
}
