using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerTrigger : MonoBehaviour
{
    private Player _player;

    public event UnityAction Eat;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
            Eat?.Invoke();

        if (other.gameObject.TryGetComponent(out Block block))
            _player.Die();
    }
}
