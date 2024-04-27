using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UpgadeUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ListCharacterSO ListTankPurchased;
    [SerializeField] private GameObject tankContainer;
    [SerializeField] private TextMeshProUGUI tankName;
    [SerializeField] private TextMeshProUGUI tankPrice;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider damageSlider;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private Button playNowBtn;
    [Space, Header("UI")]
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button beforeBtn;
    private List<CharacterSO> listTankChractersSO = new List<CharacterSO>();
    [SerializeField] private List<GameObject> listTankGameObject = new List<GameObject>();
    private CharacterSO currentTankShow;
    int tankIndex = 0;

    void OnEnable()
    {
        SpawnTankPurchased();
        currentTankShow = listTankChractersSO[tankIndex];
        PlayerData.Instance.UpgadeUI_OnChangeCharacterSO(currentTankShow);
        SetTankInfor(currentTankShow);
        listTankGameObject[tankIndex].SetActive(true);
        nextBtn.onClick.AddListener(() => {
            ShowTankNext();
         });
        beforeBtn.onClick.AddListener(() => {
            ShowTankPrevious();
        });
        playNowBtn.onClick.AddListener(() => { gameObject.SetActive(false); SceneManager.LoadScene(1); });
        SetGoldText();
        upgradeBtn.onClick.AddListener(() => { UpgradeTank(); });
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

    public void SpawnTankPurchased()
    {
        foreach (var tankSO in ListTankPurchased.ListTanklistOfpurchasedTanks)
        {
           var tank = Instantiate(tankSO.characterPrefab,tankContainer.transform);
           tank.SetActive(false);
           listTankChractersSO.Add(tankSO);
           listTankGameObject.Add(tank);
        }
    }

    public void SetTankInfor(CharacterSO tankSO)
    {
        this.tankName.text = tankSO.characterName;
        this.tankPrice.text = tankSO.charaterPrice.ToString();
        this.damageSlider.value = (float)tankSO.characterDamage;
        this.hpSlider.value = (float)tankSO.characterHP;
        this.speedSlider.value = (float)tankSO.characterSpeed;
    }

    public void ShowTankNext()
    {
        tankIndex += 1;
        if(tankIndex < listTankGameObject.Count)
        {
            listTankGameObject[tankIndex].SetActive(true);
            currentTankShow = listTankChractersSO[tankIndex];
            listTankGameObject[tankIndex - 1].SetActive(false);
            SetTankInfor(currentTankShow);
            PlayerData.Instance.UpgadeUI_OnChangeCharacterSO(currentTankShow);
        }
        else
        {
            tankIndex = listTankGameObject.Count-1;
        }
    }  

    public void ShowTankPrevious()
    {
        tankIndex -= 1;
        if(tankIndex >= 0)
        {
            listTankGameObject[tankIndex].SetActive(true);
            currentTankShow = listTankChractersSO[tankIndex];
            listTankGameObject[tankIndex + 1].SetActive(false);
            SetTankInfor(currentTankShow);
            PlayerData.Instance.UpgadeUI_OnChangeCharacterSO(currentTankShow);
        }
        else
        {
            tankIndex = 0;
        }
    }

    public void UpgradeTank()
    {
        if (PlayerData.Instance.gold >= int.Parse(tankPrice.text))
        {
            Debug.Log("upgrade tank");
            PlayerData.Instance.ConsumeGold(int.Parse(tankPrice.text));
            UpgradeCharacterSO();
            SetTankInfor(currentTankShow);
        }
        else
        {
            Debug.Log("You dont have enough money");
        }
    }

    public void UpgradeCharacterSO()
    {
        currentTankShow.currentLevel += 1;
        currentTankShow.characterDamage += 10;
        currentTankShow.characterHP += 3;
        currentTankShow.characterSpeed += 5;
    }

    public void SetGoldText()
    {
        goldText.text = PlayerData.Instance.gold.ToString();
    }

    public CharacterSO GetCharacterSO()
    {
        return currentTankShow = listTankChractersSO[tankIndex];
    }
}
