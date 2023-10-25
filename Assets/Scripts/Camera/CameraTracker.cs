using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _zOffset = 15;
    private int _yOffset = 23;

    private void Update()
    {
        transform.position = new Vector3(
            _player.transform.position.x,
            _player.transform.position.y+ _yOffset,
            _player.transform.position.z - _zOffset);
    }
}
