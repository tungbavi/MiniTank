using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RespawnUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private BattleUI battleUI;
    void Start()
    {
        continueButton.onClick.AddListener(() => {

            if (PlayerData.Instance.gold >= 500)
            {
                PlayerData.Instance.ConsumeGold(500);
                gameObject.SetActive(false);
                playerHealth.AddLifeCount();
                playerHealth.Respawn();
            }

        });
        quitButton.onClick.AddListener(() => {
            battleUI.SetLoseScene();
            gameObject.SetActive(false);
        });
    }
}
