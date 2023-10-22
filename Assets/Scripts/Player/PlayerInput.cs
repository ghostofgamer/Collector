using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //float angel = _joystick.Horizontal;
        float angel = Input.GetAxis("Horizontal");
        _playerMovement.Rotate(angel);
    }
}
