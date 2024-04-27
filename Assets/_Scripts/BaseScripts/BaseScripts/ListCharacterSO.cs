using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ListCharacterSO : ScriptableObject
{
    public List<CharacterSO> ListTanklistOfUnpurchasedTanks = new List<CharacterSO>();
    public List<CharacterSO> ListTanklistOfpurchasedTanks = new List<CharacterSO>();
}
