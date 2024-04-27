using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class TankSlotUI : MonoBehaviour
{
    public event EventHandler<GetCharacterSOArg> OnShowPreview;
    public class GetCharacterSOArg : EventArgs { public CharacterSO CharacterSO; }
    private CharacterSO CharacterTank;
    public CharacterSO CharacterSO { get { return CharacterTank; } }
    [SerializeField] Image tankIcon;
    [SerializeField] TextMeshProUGUI tankName;
    [SerializeField] TextMeshProUGUI tankPriceText;
    [SerializeField] private Button buttonShowInforTank; 
    [SerializeField] private Button buttonBuy; 

    private void Start()
    {
        buttonShowInforTank.onClick.AddListener(() => {
            UIManager.Instance.ShowPreviewScene();
            OnShowPreview?.Invoke(this, new GetCharacterSOArg { CharacterSO = CharacterTank });
        });
        buttonBuy.onClick.AddListener(() => {
            UIManager.Instance.ShowPreviewScene();
            OnShowPreview?.Invoke(this, new GetCharacterSOArg { CharacterSO = CharacterTank });
        });
    }

    public void SetTankInfor(CharacterSO CharacterTank, Sprite tankIcon, string tankName, int tankPrice)
    {
        this.CharacterTank = CharacterTank;
        this.tankIcon.sprite = tankIcon;
        this.tankName.text = tankName;
        this.tankPriceText.text = tankPrice.ToString();
    }

    public CharacterSO GetCharacterSO() 
    { 
        return CharacterTank; 
    }
}
