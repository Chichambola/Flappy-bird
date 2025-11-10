using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Coroutine _coroutine;

    private void OnEnable()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Move());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            gameObject.transform.position += transform.right * _speed * Time.deltaTime;
            
            yield return null;
        }
    }
}
