using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _loaderTxt;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);

    public void Load(string sceneName)
    {
        _loadingScreen.SetActive(true);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(LoadAsync(sceneName));
    }

    private IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneName);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            _slider.value = loadAsync.progress;
            _loaderTxt.text = (_slider.value * 100).ToString();

            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return _waitForSeconds;
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
