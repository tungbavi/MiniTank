using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinSceneUI : MonoBehaviour
{
    [Header("Id Scene")]
    [SerializeField] private int idSceneNext;
    [Header("Buttons")]
    [SerializeField] private Button homeButton;
    [SerializeField] private Button nextButton;

    void Start()
    {
        PlayerData.Instance.AddGold(300);
        homeButton.onClick.AddListener(() => { 
            SceneManager.LoadScene(0);
            gameObject.SetActive(false);
        });
        nextButton.onClick.AddListener(() => { 
            SceneManager.LoadScene(idSceneNext);
            gameObject.SetActive(false);
        });
    }
}
