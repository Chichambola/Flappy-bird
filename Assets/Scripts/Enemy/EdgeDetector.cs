using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetector : MonoBehaviour
{
    public event Action OffEdgeDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ReleaseArea _))
        {
            OffEdgeDetected?.Invoke();
        }
    }
}
