using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructive : MonoBehaviour, IDamageable
{
    public DestructiveType destructiveType;

    public void ReciveDamage(float damage, CharacterType type)
    {
        switch(destructiveType)
        {
            case DestructiveType.Brick:
                {
                    gameObject.SetActive(false);
                    break;
                }
            case DestructiveType.Steel:
                break;
            case DestructiveType.Tower:
                {
                    if(type == CharacterType.enemy)
                    {
                        GetComponent<BaseCharacterHealth>().ReciveDamage(damage, type);
                    }
                    break;
                } 
        }
    }
}
