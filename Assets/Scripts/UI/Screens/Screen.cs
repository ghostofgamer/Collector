using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Screen : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Open()
    {
        Time.timeScale = 0f;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts =true;
    } 

    public virtual void Close()
    {
        Time.timeScale = 1f;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}
