using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CharacterType { player, enemy, other }
[CreateAssetMenu]
public class CharacterSO : ScriptableObject
{
    public CharacterType characterType;
    public GameObject characterPrefab;
    public Sprite characterIcon;
    public int characterDamage;
    public int characterHP;
    public int characterSpeed;
    public string characterName;
    public int charaterPrice;
    public int currentLevel;
}

