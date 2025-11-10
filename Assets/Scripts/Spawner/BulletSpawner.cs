using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Action = UnityEngine.Events.UnityAction;


public class BulletSpawner : Spawner<Bullet>
{
    public void GetBullet()
    {
        GetObject();
    }
    
    protected override void ActionOnGet(Bullet bullet)
    {
        base.ActionOnGet(bullet);
        
        bullet.transform.position = SpawnArea.bounds.center;
        
        bullet.transform.rotation = gameObject.transform.rotation;
    }
}
