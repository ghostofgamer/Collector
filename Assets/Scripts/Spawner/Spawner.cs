using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Food[] _prefabs;
    [SerializeField] private Cart[] _cartPrefabs;
    [SerializeField] private Transform _container;
    [SerializeField] private Player _player;

    private int _count = 60;
    private bool _autoExpand = true;
    private ObjectPool<Food> _pool;
    private ObjectPool<Cart> _poolCart;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private void OnEnable()
    {
        _player.GetComponent<PlayerTrigger>().Eat += CartSpawn;
    }

    private void OnDisable()
    {
        _player.GetComponent<PlayerTrigger>().Eat -= CartSpawn;
    }

    private void Start()
    {
        _poolCart = new ObjectPool<Cart>(_cartPrefabs, _count, _container, _autoExpand);
        _pool = new ObjectPool<Food>(_prefabs, _count, _container, _autoExpand);
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
            int randomIndex = Random.Range(0, _prefabs.Length);

            if (_pool.TryGetObject(out Food food, _prefabs[randomIndex]))
            {
                float positionX = Random.Range(_minPositionX, _maxPositionX);
                float positionZ = Random.Range(_minPositionZ, _maxPositionZ);
                Vector3 spawnPosition = new Vector3(positionX, transform.position.y, positionZ);
                food.transform.position = spawnPosition;
            }

            yield return _waitForSeconds;
        }
    }

    public void CartSpawn()
    {
        int randomIndex = Random.Range(0, _cartPrefabs.Length);

        if (_poolCart.TryGetObject(out Cart cart, _cartPrefabs[randomIndex]))
        {
            cart.transform.position = _player.Tails[_player.Tails.Count - 1].position;
            _player.AddTailsss(cart.transform);
        }
    }
}
