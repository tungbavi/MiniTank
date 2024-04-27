using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TankSlotUI tankSlot;
    [SerializeField] private TankPreviewUI tankPreviewUI;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private ListCharacterSO ListCharacterSO;
    [SerializeField] private GameObject content;
    private List<TankSlotUI> listTankSlotUI = new List<TankSlotUI>();

    void Start()
    {
        SpawnTankSlot();
        GetEventCharacterSOInTankSlotUI();
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

    private void GetEventCharacterSOInTankSlotUI()
    {
        foreach (var tankSlotUI in listTankSlotUI)
        {
            tankSlotUI.OnShowPreview += TankSlotUI_OnShowPreview;
            tankPreviewUI.SpawnTankInContainer(tankSlotUI.GetCharacterSO());
        }
    }

    private void TankSlotUI_OnShowPreview(object sender, TankSlotUI.GetCharacterSOArg e)
    {
        tankPreviewUI.GetTankSO(e.CharacterSO);
        tankPreviewUI.SetTankInfor(e.CharacterSO);
        tankPreviewUI.SetContructorIsShowing(e.CharacterSO);
        tankPreviewUI.ActiveTankModel();
    }

    private void SpawnTankSlot()
    {
        for (int i = 0; i < ListCharacterSO.ListTanklistOfUnpurchasedTanks.Count; i++)
        {
            var tankslot = Instantiate(tankSlot, content.transform);
            listTankSlotUI.Add(tankslot);
            tankslot.SetTankInfor(ListCharacterSO.ListTanklistOfUnpurchasedTanks[i], ListCharacterSO.ListTanklistOfUnpurchasedTanks[i].characterIcon,
                ListCharacterSO.ListTanklistOfUnpurchasedTanks[i].characterName, ListCharacterSO.ListTanklistOfUnpurchasedTanks[i].charaterPrice);
        }
    }

    public void ResetTankSlot(CharacterSO characterSO)
    {
        for (int i = 0; i < listTankSlotUI.Count; i++)
        {
            if(listTankSlotUI[i].CharacterSO == characterSO)
            {
                DestroyImmediate(listTankSlotUI[i].gameObject);
                return;
            }
        }
    }

    public List<TankSlotUI> GetListtankUI()
    {
       return listTankSlotUI;
    }

    public void SetGoldText()
    {
        goldText.text = PlayerData.Instance.gold.ToString();
    }
}
