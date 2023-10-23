using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : AbstractionButton
{
    [SerializeField] private Screen _screen;

    public override void OnClick()
    {
        _screen.Open();
    }
}
