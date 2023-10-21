using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private List<Cart> _carts;

    [SerializeField] private Transform _prefabs;
    [SerializeField] private Transform _container;

    public event UnityAction Eat;

    public List<Transform> Tails => _tails;

    public void AddTail()
    {
        Eat?.Invoke();
         //Transform tail = Instantiate(_prefabs, _container);
        //tail.SetActive(false);
        //tail.SetActive(true);
        //tail.transform.position = _tails[_tails.Count - 1].position;
        //_tails.Add(tail);
        //_tails.Add(tail.transform);
    }

    public void AddTailsss(Transform transform)
    {
        _tails.Add(transform);
    }

    public void Die()
    {
        Debug.Log("ударился");
    }
}
