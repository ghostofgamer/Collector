using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speedRotate;
    [Range(0, 15)]
    [SerializeField] private int _speedMove;
    [Range(0, 100)]
    [SerializeField] private int _gap;

    private List<Vector3> _positionHistory = new List<Vector3>();
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

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

    private void TalesMovement()
    {
        _positionHistory.Insert(0, transform.position);
        int index = 0;

        foreach (var tail in _player.Tails)
        {
            Vector3 point = _positionHistory[Mathf.Min(index * _gap, _positionHistory.Count - 1)];
            Vector3 moveDirection = point - tail.transform.position;
            tail.transform.position += moveDirection * _speedMove * Time.deltaTime;
            tail.transform.LookAt(point);
            index++;
        }
    }
}
