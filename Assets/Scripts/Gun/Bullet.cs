using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable, IInteractable
{
    public event Action<Bullet> IsHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ReleaseArea _))
        {
            IsHit?.Invoke(this);
        }
    }
}
