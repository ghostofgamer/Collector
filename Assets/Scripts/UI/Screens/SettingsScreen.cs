using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : Screen
{
    [SerializeField] private bool _isMainMenu = false;

    public override void Close()
    {
        base.Close();

        if (!_isMainMenu)
            Time.timeScale = 0;
    }
}