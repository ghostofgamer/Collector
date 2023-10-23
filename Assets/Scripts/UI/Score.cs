using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTxt;
    [SerializeField] private ParticleSystem[] _effectParticles;
    [SerializeField] private Transform _particlePosition;

    private float _score;
    private int _speed = 135;
    private int _needScore = 100;
    private Coroutine _coroutine;

    private void Update()
    {
        _scoreTxt.text = (_score += _speed * Time.deltaTime).ToString("0");

        if (_score > _needScore)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(PlayParticles());
            _needScore += 300;
        }
    }

    private IEnumerator PlayParticles()
    {
        Instantiate(_effectParticles[Random.Range(0, _effectParticles.Length)], _particlePosition);
        yield return null;
    }
}
