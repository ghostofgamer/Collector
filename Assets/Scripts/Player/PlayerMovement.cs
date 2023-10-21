using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private GameObject _prefabs;
    [SerializeField] private Transform _container;
    [SerializeField] private int _speedRotate;
    [Range(0, 5)]
    [SerializeField] private int _speedMove;
    [Range(0, 100)]
    [SerializeField] private int _gap;

    private List<Vector3> _positionHistory = new List<Vector3>();

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * _speedMove * Time.deltaTime;
        TalesMovement();
    }

    public void Rotate(float angel)
    {
        transform.Rotate(0, angel * _speedRotate * Time.deltaTime, 0);
    }

    public void AddTail()
    {
        GameObject tail = Instantiate(_prefabs, _container);
        tail.SetActive(false);
        tail.transform.position = _tails[_tails.Count - 1].position;
        tail.SetActive(true);

        _tails.Add(tail.transform);
    }

    private void TalesMovement()
    {
        _positionHistory.Insert(0, transform.position);
        int index = 1;

        foreach (var tail in _tails)
        {
            Vector3 point = _positionHistory[Mathf.Min(index * _gap, _positionHistory.Count - 1)];
            Vector3 moveDirection = point - tail.transform.position;
            tail.transform.position += moveDirection * 15 * Time.deltaTime;
            tail.transform.LookAt(point);
            index++;
        }
    }
}
