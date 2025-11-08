using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    public void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, transform.rotation.z));
    }
}
