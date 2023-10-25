using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPatrolMainMenu : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private List<Transform> _points;
    private Transform _target;
    private int _currentPoint = 0;
    private float _speed = 16f;
    private float _speedRotation = 6f;

    private void Start()
    {
        _points = new List<Transform>();

        for (int i = 0; i < _path.childCount; i++)
            _points.Add(_path.GetChild(i));
    }

    private void Update()
    {
        _target = _points[_currentPoint];
        Vector3 relativePosition = transform.position - _target.position;
        Quaternion rotation = Quaternion.LookRotation(relativePosition);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);

        if (transform.position == _target.position)
            NextPoint();
    }

    private void NextPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Count)
            _currentPoint = 0;
    }
}
