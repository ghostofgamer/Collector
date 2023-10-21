using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    //private T _prefab;
    private T[] _prefabs;
    private List<T> _poolGeneric;

    //////public ObjectPool(T prefab, int count, Transform container, bool autoExpand )
    //////{
    //////    _prefab = prefab;
    //////    _container = container;
    //////    AutoExpand = autoExpand;
    //////    GetInitialization(count, prefab);
    //////}

    public ObjectPool(T[] prefabs, int count, Transform container, bool autoExpand)
    {
        _prefabs = prefabs;
        _container = container;
        AutoExpand = autoExpand;
        GetInitialization(count, prefabs);
    }

    public bool AutoExpand { get; private set; }

    public bool TryGetObject(out T spawned, T prefabs)
    {
        var filter = _poolGeneric.Where(p => p.gameObject.activeSelf == false);
        var index = Random.Range(0, filter.Count());

        if (filter.Count() == 0 && AutoExpand)
        {
            spawned = CreateObject(prefabs);
            return spawned != null;
        }

        spawned = filter.ElementAt(index);
        spawned.gameObject.SetActive(true);
        return spawned != null;
    }

    private T CreateObject(T prefab)
    {
        var spawned = Object.Instantiate<T>(prefab, _container.transform);
        spawned.gameObject.SetActive(true);
        _poolGeneric.Add(spawned);
        return spawned;
    }

    private void GetInitialization(int count,T[] prefabs)
    {
        _poolGeneric = new List<T>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            var spawned = Object.Instantiate<T>(prefabs[randomIndex], _container.transform);
            spawned.gameObject.SetActive(false);
            _poolGeneric.Add(spawned);
        }
    }
}
