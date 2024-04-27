using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using System.Reflection;
public class TankPreviewUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private TextMeshProUGUI tankName;
    [SerializeField] private TextMeshProUGUI tankPrice;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider damageSlider;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button buyBtn;
    [SerializeField] private ListCharacterSO ListTank;
    [Header("Tank Container")]
    [SerializeField] private Transform tankContainer;
    private CharacterSO tankSO;
    private List<GameObject> TankList = new List<GameObject>();
    private GameObject tankIsShowing;

    private void OnEnable()
    {
        SetGoldText();
        PlayerData.Instance.OnAddGoldValue += Instance_OnAddGoldValue;
        PlayerData.Instance.OnConsumeGoldValue += Instance_OnConsumeGoldValue;
    }

    private void Instance_OnConsumeGoldValue(int obj)
    {
        SetGoldText();
    }

    private void Instance_OnAddGoldValue(int obj)
    {
        SetGoldText();
    }

    private void Start()
    {
        exitBtn.onClick.AddListener(() => { UIManager.Instance.ShowShopScene(); });
        buyBtn.onClick.AddListener(() => { 
            BuyTank();
            UIManager.Instance.ShowPurchasedScene();
        });
    }

    public void SetTankInfor(CharacterSO tankSO)
    {
        this.tankName.text = tankSO.characterName;
        this.tankPrice.text = tankSO.charaterPrice.ToString();
        this.damageSlider.value = (float)tankSO.characterDamage / 100;
        this.hpSlider.value = (float)tankSO.characterHP / 100;
        this.speedSlider.value = (float)tankSO.characterSpeed / 100;
    }

    public void SpawnTankInContainer(CharacterSO tankSO)
    {
        var tank = Instantiate(tankSO.characterPrefab, tankContainer);
        tank.AddComponent<TankInformation>().SetTankInformation(tankSO);
        TankList.Add(tank);
    }

    public void SetContructorIsShowing(CharacterSO tankSO)
    {
        for (int i = 0; i < TankList.Count; i++)
        {
            if (TankList[i].GetComponent<TankInformation>().TankInfor == tankSO)
            {
                this.tankIsShowing = TankList[i];
            }
        }
    }

    public void ActiveTankModel()
    {
        this.tankIsShowing.SetActive(true);
        for (int i = 0; i < TankList.Count; i++)
        {
            if (TankList[i] != tankIsShowing)
            {
                TankList[i].SetActive(false);
            }
        }
    }

    public void BuyTank()
    {
        if(PlayerData.Instance.gold >= int.Parse(tankPrice.text))
        {
            shopUI.ResetTankSlot(tankSO);
            ListTank.ListTanklistOfpurchasedTanks.Add(tankSO);
            ListTank.ListTanklistOfUnpurchasedTanks.Remove(tankSO);
            PlayerData.Instance.ConsumeGold(int.Parse(tankPrice.text));
            SetGoldText();
            shopUI.SetGoldText();
        }
        else
        {
            Debug.Log("You dont have enough money");
            return;
        }
    }

    public void GetTankSO(CharacterSO characterSO)
    {
        tankSO = characterSO;
    }

    public void SetGoldText()
    {
        goldText.text = PlayerData.Instance.gold.ToString();
    }
}
