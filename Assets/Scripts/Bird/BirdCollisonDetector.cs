using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisonDetector : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnеTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            Debug.Log(interactable);
            
            CollisionDetected?.Invoke(interactable);
        }
    }
}
