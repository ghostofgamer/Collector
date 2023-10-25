using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    [SerializeField] private bool _isMainMenu = false;
    [SerializeField] private AudioSource _audioSource;

    public void SetVolume(Slider slider)
    {
        _audioSource.volume = slider.value;
    }

    public void OnMute()
    {
        _audioSource.mute = true;
    }

    public void OffMute()
    {
        _audioSource.mute = false;
    }

    public override void Close()
    {
        base.Close();

        if (!_isMainMenu)
            Time.timeScale = 0;
    }
}