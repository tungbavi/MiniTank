using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PurchaseSuccessfulUI : MonoBehaviour
{
    [SerializeField] private Button closeSceneBtn;

    void Start()
    {
        closeSceneBtn.onClick.AddListener(() => { UIManager.Instance.ShowShopScene(); });   
    }
}
