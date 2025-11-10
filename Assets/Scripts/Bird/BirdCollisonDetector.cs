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

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}
