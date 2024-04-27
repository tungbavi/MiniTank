using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void ReciveDamage(float damage, CharacterType type = CharacterType.other);
}
