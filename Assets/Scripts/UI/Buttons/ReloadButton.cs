using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : AbstractionButton
{
    [SerializeField] private SceneLoader _sceneLoader;

    public override void OnClick()
    {
        Time.timeScale = 1;
        _sceneLoader.Load(SceneManager.GetActiveScene().name);
    }
}
