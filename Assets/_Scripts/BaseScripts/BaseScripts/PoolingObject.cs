using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : Singleton<PoolingObject>
{
    public void addPool(GameObject prefab, List<GameObject> listPool, int Amount, Transform parent)
    {
        for (int i = 0; i < Amount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(parent);
            obj.name = prefab.name;
            obj.SetActive(false);
            listPool.Add(obj);
        }
    }
    public GameObject GetPoolingobj(List<GameObject> listPool)
    {
        for (int i = 0; i < listPool.Count; i++)
        {
            if (!listPool[i].activeInHierarchy)
            {
                return listPool[i];
            }
        }
        return null;
    }
}

