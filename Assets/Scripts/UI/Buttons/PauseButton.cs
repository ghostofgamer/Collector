using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : AbstractionButton
{
    [SerializeField] private PauseScreen _pauseScreen;

    public override void OnClick()
    {
        _pauseScreen.Open();
    }
}
