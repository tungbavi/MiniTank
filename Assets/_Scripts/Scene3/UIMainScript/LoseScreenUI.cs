using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoseScreenUI : MonoBehaviour
{
    [Header("Id Scene")]
    [SerializeField] private int idScene;
    [Header("Buttons")]
    [SerializeField] private Button homeButton;
    [SerializeField] private Button restartButton;

    void Start()
    {
        homeButton.onClick.AddListener(() => { 
            SceneManager.LoadScene(0); 
            gameObject.SetActive(false);
        });
        restartButton.onClick.AddListener(() => { 
            SceneManager.LoadScene(idScene);
            gameObject.SetActive(false);
        });
    }
}
