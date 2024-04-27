using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadingUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image loadingFill;
    [SerializeField] private float timeLoadingMax;
    private float timeLoading;

    void Start()
    {
        loadingFill.fillAmount = 0;
    }

    void Update()
    {
        Loading();
    }

    public void Loading()
    {
        if(timeLoading >= timeLoadingMax)
        {
            UIManager.Instance.ShowHomeScene();
            gameObject.SetActive(false);
            return;
        }
        else
        {
            timeLoading += Time.deltaTime;
        }
        float percentLoading = timeLoading / timeLoadingMax;
        loadingFill.fillAmount = percentLoading;
    }
}
