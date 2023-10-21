using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFood : MonoBehaviour
{
    [SerializeField] private Food _prefab;
    [SerializeField] private Transform _container;

    private int _count = 60;
    private bool _autoExpand = true;
    private ObjectPool<Food> _pool;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private void Start()
    {
        _pool = new ObjectPool<Food>(_prefab, _count, _container, _autoExpand);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int _minPositionX = -25;
        int _maxPositionX = 21;
        int _minPositionZ = 3;
        int _maxPositionZ = 45;

        while (true)
        {
            if (_pool.TryGetObject(out Food food, _prefab))
            {
                float positionX = Random.Range(_minPositionX, _maxPositionX);
                float positionZ = Random.Range(_minPositionZ, _maxPositionZ);
                Vector3 spawnPosition = new Vector3(positionX, transform.position.y, positionZ);
                food.transform.position = spawnPosition;
            }

            yield return _waitForSeconds;
        }
    }
}
