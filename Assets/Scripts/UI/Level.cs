using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _tailsCountToNextLevelTxt;
    [SerializeField] private TMP_Text _currentCountTailTxt;
    [SerializeField] private TMP_Text _currentLevelTxt;
    [SerializeField] private ParticleSystem[] _effectParticles;
    [SerializeField] private Transform _particlePosition;

    private int _currentLevel = 1;
    private int _tailsCountToNextLevel = 1;

    public event UnityAction Extension;

    private void OnEnable()
    {
        _player.PickUp += OnPickUp;
    }

    private void OnDisable()
    {
        _player.PickUp -= OnPickUp;
    }

    private void Start()
    {
        _slider.value = 0;
        ShowInfo((int)_slider.value);
    }

    private void OnPickUp()
    {
        ShowInfo(_player.Tails.Count);

        if (_player.Tails.Count >= _tailsCountToNextLevel)
        {
            RaiseLevel();
            ShowInfo(_player.Tails.Count);
        }
    }

    private void ShowInfo(int value)
    {
        _slider.maxValue = _tailsCountToNextLevel;
        _slider.value = value;
        _currentLevelTxt.text = _currentLevel.ToString();
        _currentCountTailTxt.text = _slider.value.ToString();
        _tailsCountToNextLevelTxt.text = _slider.maxValue.ToString();
    }

    private void RaiseLevel()
    {
        _currentLevel++;
        _tailsCountToNextLevel += 1;
        Extension?.Invoke();
        Instantiate(_effectParticles[Random.Range(0, _effectParticles.Length)], _particlePosition);
    }
}
