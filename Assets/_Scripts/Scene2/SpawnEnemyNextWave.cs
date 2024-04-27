using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyNextWave : SpawnManager
{
   private int enemyDead =0;
   private int totalEnemyDead =0;
   [SerializeField] private BattleUI battleUI;
   [SerializeField] private TextMeshProUGUI totalEnemyDefeatedLose;
   [SerializeField] private TextMeshProUGUI totalEnemyDefeatedWin;
   protected int totalEnemy;
   protected void Start()
   {
      AddCharacterNeedSpawnInToList();
      PoolingObjectWithCharacterPrefabInDic();
      SpawnPrefab();
      AddEventEnemy();
      totalEnemy = baseWave.CountTotalEnemy();
        battleUI.SetProgressValue(totalEnemy);
   }

   private void Update()
   {
      if (baseWave.CheckCurrentWave())
      {
         battleUI.SetWinScene();
         totalEnemyDefeatedWin.text ="+ "+ totalEnemyDead.ToString();
      }
   }

   public void SetTotalEnemyDefeated()
   {
      totalEnemyDefeatedLose.text ="+ "+ totalEnemyDead.ToString();
   }
   private void AddEnemyDeadToList()
   {
      enemyDead++;
      totalEnemyDead++;
      totalEnemy--;
      battleUI.SetValueProgressSlider(totalEnemy);
      if (enemyDead == characterGOs.Count)
      {
         enemyDead = 0;
         baseWave.IncreaseCurrentWave();
         AddCharacterNeedSpawnInToList();
         PoolingObjectWithCharacterPrefabInDic();
         SpawnPrefab();
         AddEventEnemy();
      }
   }

   public void AddEventEnemy()
   {
      foreach (var GO in characterGOs)
      {
         GO.GetComponent<EnemyHealth>().IsDead += AddEnemyDeadToList;
      }
   }
}
