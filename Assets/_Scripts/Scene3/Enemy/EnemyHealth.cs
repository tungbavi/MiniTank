using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BaseCharacterHealth
{
    public event Action IsDead;
    void OnDisable()
    {
        if (isDead)
        {
            IsDead?.Invoke();
        }
    }
}
