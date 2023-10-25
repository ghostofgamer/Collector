using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : AbstractionButton
{
    [SerializeField] private SceneLoader _sceneLoader;

    private string MainMenuScene = "MainMenu";

    public override void OnClick()
    {
        Time.timeScale = 1;
        _sceneLoader.Load(MainMenuScene);
    }
}
