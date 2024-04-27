using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : BaseCharacterHealth
{
    [Header("Total Lives")]
    [SerializeField] private int lifeCount;
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private TextMeshProUGUI textLifeCount;
    [SerializeField] private BattleUI battleUI;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private SpawnEnemyNextWave spawnEnemyNextWave;
    
    protected override void Start()
    {
        base.Start();
        lifeCount = 3;
        isDead = false;
        textLifeCount.text = lifeCount.ToString();
    }
    
    private void OnDisable()
    {
        RespawnPlayerAfterDead();
    }

    private void RespawnPlayerAfterDead()
    {
        if (isDead)
        {
            lifeCount--;
            Debug.Log(lifeCount);
            if (lifeCount > 0)
            {
               Invoke("Respawn",1f);
            }
            else
            {
                lifeCount = 0;
                battleUI.SetRespawnCanvas();
                spawnEnemyNextWave.SetTotalEnemyDefeated();
            }
            textLifeCount.text = lifeCount.ToString();
            
        }
    }

    public void Respawn()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = respawnPosition.position;
            currentHealth = maxHealth;
            healthUI.SpawnHealthUI();
            isDead = false; 
        }
    }

    public void AddLifeCount()
    {
        lifeCount+=1;
        textLifeCount.text = lifeCount.ToString();
    }
}
