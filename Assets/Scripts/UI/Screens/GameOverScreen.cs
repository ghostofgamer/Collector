using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : Screen
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Dying += OnDying;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDying;
    }

    private void OnDying()
    {
        Open();
    }
}