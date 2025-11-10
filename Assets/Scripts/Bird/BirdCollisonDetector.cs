using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisonDetector : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private Bird _bird;
    
    private void Awake()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}
