using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;
    private Vector3 _direction;

    private void OnEnable()
    {
        _direction = Vector3.up;
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    public void StartMoving()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            transform.Translate(_speed * Time.deltaTime * _direction);

            yield return null;
        }
    }

    public void ToggleDirection()
    {
        if (_direction == Vector3.up)
            _direction = Vector3.down;
        else if (_direction == Vector3.down)
            _direction = Vector3.up;
    }
}
