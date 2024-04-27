using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : Singleton<EffectController>
{
    [Header("effects hit")]
    [SerializeField] private GameObject effectHitPrefab;
    private List<GameObject> listEffectHit = new List<GameObject>();

    void Start()
    {
        PoolingObject.Instance.addPool(effectHitPrefab, listEffectHit, 20, transform);
    }

    public List<GameObject> GetListEffectHit()
    {
        return listEffectHit;
    }

}
