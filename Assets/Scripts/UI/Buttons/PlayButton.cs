using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : AbstractionButton
{
    [SerializeField] private SceneLoader _sceneLoader;

    private string _level = "Scene1";

    public override void OnClick()
    {
        _sceneLoader.Load(_level);
    }
}
