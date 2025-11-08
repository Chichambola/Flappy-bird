using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] private T _objectPrefab;
    [SerializeField] protected int PoolCapacity;
    [SerializeField] protected int MaxPoolCapacity;
    [SerializeField] protected float NumberOfActiveObjects;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
            (
            createFunc: CreateObject,
            actionOnGet: ActionOnGet,
            actionOnRelease: ActionOnRelease,
            actionOnDestroy: @object => Destroy(@object.gameObject),
            collectionCheck: true,
            defaultCapacity: PoolCapacity,
            maxSize: MaxPoolCapacity);
    }

    private T CreateObject()
    {
        return Instantiate(_objectPrefab);
    }

    protected virtual void ActionOnGet(T @object)
    {
        @object.gameObject.SetActive(true);
    }

    protected void Release(T @object)
    {
        if(@object.gameObject.activeSelf)
        {
            _pool.Release( @object );
        }
    }

    protected virtual void ActionOnRelease(T @object)
    {
        @object.gameObject.SetActive(false);

        @object.ResetCharacteristics();
    }
}
