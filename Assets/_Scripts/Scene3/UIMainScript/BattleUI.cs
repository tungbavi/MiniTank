using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [Header("Canvas Components")]
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider progressSlider;

    [Header("Different Canvas")]
    [SerializeField] private GameObject pausedGameCanvas;
    [SerializeField] private GameObject loseGameCanvas;
    [SerializeField] private GameObject winGameCanvas;
    [SerializeField] private GameObject respawnCanvas;
    private bool isSave;
    [SerializeField] protected BaseWave baseWave;
    private int timeToRespawn = 1;
    private void Start()
    {
        pausedGameCanvas.SetActive(false);
        loseGameCanvas.SetActive(false);
        winGameCanvas.SetActive(false);
        respawnCanvas.SetActive(false);
    }

    public void SetValueProgressSlider(int value)
    {
        progressSlider.value = value;
    }

    public void SetPauseGameCanvas()
    {
        pausedGameCanvas.SetActive(!pausedGameCanvas.activeSelf);
        Debug.Log(pausedGameCanvas.activeSelf);
        Time.timeScale = !pausedGameCanvas.activeSelf ? 1 : 0;
    }

    public void SetRespawnCanvas()
    {
        if(timeToRespawn >0)
        {
            timeToRespawn--;
            respawnCanvas.SetActive(true);
        }
        else
        {
            SetLoseScene();
        }
    }
    public void SetWinScene()
    {
        winGameCanvas.SetActive(true);
    }
    public void SetLoseScene()
    {
        loseGameCanvas.SetActive(true);
    }
   
    public void SetProgressValue(int totalEnemy)
    {
        progressSlider.maxValue = totalEnemy;
    }
}
