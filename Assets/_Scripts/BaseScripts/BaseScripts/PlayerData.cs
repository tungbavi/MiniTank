using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerData : Singleton<PlayerData>
{
    public event Action<int> OnConsumeGoldValue;
    public event Action<int> OnAddGoldValue;
    [SerializeField]private int Gold = 10000;
    public int gold => Gold;
    private CharacterSO playerTankModel;
    public CharacterSO PlayerTankModel => playerTankModel;
    [SerializeField] private ListCharacterSO playerListTank;

    private void Start()
    {
        playerTankModel = playerListTank.ListTanklistOfpurchasedTanks[0];
    }

    public void UpgadeUI_OnChangeCharacterSO(CharacterSO obj)
    {
        playerTankModel = obj;
    }

    public void ConsumeGold(int value)
    {

        Gold -= value;
        OnConsumeGoldValue.Invoke(gold);
    }

    public void AddGold(int value)
    {
        Gold += value;
        OnAddGoldValue.Invoke(gold);
    }
}
