using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Rigidbody2D _rigidbody;
    private Coroutine _coroutine;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _startPosition = gameObject.transform.position;
        _startRotation = gameObject.transform.rotation;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    public void Move()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _rigidbody.velocity = new Vector2(_speed, _tapForce);
       
        gameObject.transform.rotation = _maxRotation;

        _coroutine = StartCoroutine(FallingRotation());
    }

    private IEnumerator FallingRotation()
    {
        while (enabled)
        {
            transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
    
    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
    }
}
    