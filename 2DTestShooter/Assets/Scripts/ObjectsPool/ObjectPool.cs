using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> _pool;
    private GameObject _prefab;

    public ObjectPool(GameObject prefab)
    {
        _pool = new List<GameObject>();
        _prefab = prefab;
    }

    public ObjectPool(GameObject prefab, int startCount)
    {
        _pool = new List<GameObject>();
        _prefab = prefab;
        for (int i = 0; i < startCount; i++)
            Create();
    }

    public GameObject Get()
    {
        foreach (GameObject obj in _pool)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        Create();
        return Get();
    }

    private GameObject Create()
    {
        GameObject go = Object.Instantiate(_prefab);
        _pool.Add(go);
        go.SetActive(false);
        return go;
    }
}
