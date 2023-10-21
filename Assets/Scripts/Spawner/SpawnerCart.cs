using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCart : MonoBehaviour
{
    [SerializeField] private Cart _tailPrefab;
    [SerializeField] private Transform _container;

    private int _count = 50;
    private ObjectPool<Cart> _pool;
    private bool _autoExpand = true;

    private void Start()
    {
        _pool = new ObjectPool<Cart>(_tailPrefab, _count, _container, _autoExpand);
    }
}
