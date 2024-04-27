using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Button playNowBtn;

    private void Start()
    {
        SetGoldtext();
        PlayerData.Instance.OnAddGoldValue += Instance_OnAddGoldValue;
        PlayerData.Instance.OnConsumeGoldValue += Instance_OnConsumeGoldValue;
        playNowBtn.onClick.AddListener(() => { SceneManager.LoadScene(1); });
    }

    private void Instance_OnConsumeGoldValue(int obj)
    {
        SetGoldtext();
    }

    private void Instance_OnAddGoldValue(int obj)
    {
        SetGoldtext();
    }

    public void SetGoldtext()
    {
        goldText.text = PlayerData.Instance.gold.ToString();
    }
}
