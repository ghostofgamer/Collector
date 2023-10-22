using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;

    public List<Transform> Tails => _tails;

    public event UnityAction PickUp;

    public void PickUpItem()
    {
        PickUp?.Invoke();
    }

    public void AddTailsss(Transform transform)
    {
        _tails.Add(transform);
    }

    public void Die()
    {
        Debug.Log("ударился");
    }
}
