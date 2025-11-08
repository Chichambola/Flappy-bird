using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    public void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        
        Debug.Log(Quaternion.identity);
    }
}
