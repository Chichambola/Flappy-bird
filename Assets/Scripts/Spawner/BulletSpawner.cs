using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Action = UnityEngine.Events.UnityAction;


public class BulletSpawner : Spawner<Bullet>
{
    private Vector3 _position;
    private Quaternion _rotation;

    public void Shoot(Vector3 position, Quaternion rotation)
    {
        _position = position;

        _rotation = rotation;

        GetObject();
    }

    public override void ReleaseAll()
    {
        if(ActiveObjects.Count != 0)
        {
            foreach (Bullet bullet in ActiveObjects.ToList())
            {
                bullet.IsHit -= Release;

                Release(bullet);
            }

            ActiveObjects.Clear();
        }
    }

    protected override void ActionOnGet(Bullet bullet)
    {
        bullet.transform.position = _position;

        bullet.transform.rotation = _rotation;

        base.ActionOnGet(bullet);

        ActiveObjects.Add(bullet);

        bullet.IsHit += Release;
    }

    protected override void ActionOnRelease(Bullet bullet)
    {
        ActiveObjects.Remove(bullet);

        base.ActionOnRelease(bullet);

        bullet.IsHit -= Release;
    }
}
