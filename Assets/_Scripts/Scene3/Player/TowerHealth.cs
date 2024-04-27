using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerHealth : BaseCharacterHealth
{
    [SerializeField] private BattleUI battleUI;

    protected override void Start()
    {
        base.Start();
        isDead = false;
    }

    private void Update()
    {
        TowerIsDead();
    }

    private void TowerIsDead()
    {
        if (isDead)
        {
            battleUI.SetLoseScene();
        }
    }
}
