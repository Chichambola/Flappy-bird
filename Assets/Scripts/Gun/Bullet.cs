using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable, IInteractable
{
    public event Action<Bullet> IsHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");

        if(collision.TryGetComponent(out ReleaseArea _))
        {
            IsHit?.Invoke(this);
        }
    }
}
