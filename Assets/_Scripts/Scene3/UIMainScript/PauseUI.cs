using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button quitButton;

    void Start()
    {
        continueButton.onClick.AddListener(() => { Time.timeScale = 1.0f; gameObject.SetActive(false); });
        quitButton.onClick.AddListener(() => { 
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        });
    }
}
