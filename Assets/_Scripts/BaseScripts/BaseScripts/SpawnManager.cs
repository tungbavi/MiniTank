using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [Header("References")]
    [SerializeField] protected BaseWave baseWave;
    private Dictionary<CharacterSO, int> prefabDictionary = new Dictionary<CharacterSO, int>();
    protected List<GameObject> characterGOs = new List<GameObject>();
    [SerializeField] Transform prefabHolder;

    // protected virtual void Start()
    // {
    //     AddCharacterNeedSpawnInToList();
    //     PoolingObjectWithCharacterPrefabInDic();
    //     SpawnPrefab();
    // }

    public void AddCharacterNeedSpawnInToList()
    {
        prefabDictionary.Clear();
        if (baseWave != null)
        {
            if (!baseWave.CheckCurrentWave())
            {
                foreach (CharacterSO character in baseWave.GetCharacaterEachWave())
                {
                    if (prefabDictionary.ContainsKey(character))
                    {
                        prefabDictionary[character] += 1;
                    }
                    else
                    {
                        prefabDictionary.Add(character, 1);
                    }
                }
            }
        }
    }

    public void PoolingObjectWithCharacterPrefabInDic()
    {
        characterGOs.Clear();

        foreach (KeyValuePair<CharacterSO, int> kvp in prefabDictionary)
        {
            PoolingObject.Instance.addPool(kvp.Key.characterPrefab, characterGOs, kvp.Value, prefabHolder);
        }
    }

    public void SpawnPrefab()
    {
        var enemy = PoolingObject.Instance.GetPoolingobj(characterGOs);
        for (int i = 0; i < characterGOs.Count; i++)
        {
            characterGOs[i].transform.position = baseWave.GetSpawnPosEachWave()[i];
            characterGOs[i].gameObject.SetActive(true);
        }
    }
    
}
