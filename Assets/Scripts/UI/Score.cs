using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTxt;

    private float _score;
    private int _speed = 135;

    private void Update()
    {
        _scoreTxt.text = (_score += _speed * Time.deltaTime).ToString("0");
    }
}
