using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseWave : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected List<InforEachWave> waveList;
    [SerializeField] protected int totalWave;
    protected int waveCurrentID = 1;
    protected int totalEnemy = 0;
    public List<CharacterSO> GetCharacaterEachWave()
    {
        foreach (InforEachWave wave in waveList)
        {
            if (waveCurrentID == wave.waveID)
                return wave.listCharacter;
        }
        return null;
    }

    public List<Vector3> GetSpawnPosEachWave()
    {
        foreach (InforEachWave wave in waveList)
        {
            if (waveCurrentID == wave.waveID)
                return wave.listSpawnPos;
        }
        return null;
    }

    public bool CheckCurrentWave()
    {
        if (waveCurrentID > totalWave)
        {
            return true;
        }

        return false;
    }

    public void IncreaseCurrentWave()
    {
        waveCurrentID += 1;
    }

    public int CountTotalEnemy()
    {
        foreach (InforEachWave count in waveList)
        {
            totalEnemy += count.listCharacter.Count;
        }

        return totalEnemy;
    }
}

[System.Serializable]
public class InforEachWave
{
    public int waveID;
    public List<Vector3> listSpawnPos;
    public List<CharacterSO> listCharacter;
}
