using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAnimation : MonoBehaviour
{
    private int _speed = 1;

    private void Update()
    {
        transform.Rotate(0, _speed, 0);
    }
}
