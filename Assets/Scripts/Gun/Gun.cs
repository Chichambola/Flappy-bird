using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    public void Shoot()
    {
        _bulletSpawner.GetBullet();
    }
}
    