using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Map : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Vector3 _direction;

    private int _speed = 1;
    private int _scale = 6;
    private Vector3 _nextPosition;

    private void OnEnable()
    {
        _level.Extension += OnExtension;
    }

    private void OnDisable()
    {
        _level.Extension -= OnExtension;
    }

    private void Update()
    {

        //transform.position = Vector3.Lerp(transform.position, _nextPosition, _speed * Time.deltaTime);
    }

    private void OnExtension()
    {
        _nextPosition = new Vector3
            (transform.position.x + _direction.x,
            transform.position.y + _direction.y,
            transform.position.z + _direction.z);
        transform.position = new Vector3(_nextPosition.x, _nextPosition.y, _nextPosition.z);

        transform.localScale = new Vector3(transform.localScale.x + _scale, transform.localScale.y, transform.localScale.z);
    }
}
