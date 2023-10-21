using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerTrigger : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
            _player.AddTail();
    }
}