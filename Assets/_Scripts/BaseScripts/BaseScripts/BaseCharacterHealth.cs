using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterHealth : MonoBehaviour, IDamageable
{
    [Header("Start Health")]
    protected float maxHealth;
    protected float currentHealth;
    public event Action<float, float> HealthChanged;
    protected bool isDead;
    [SerializeField] private BaseCharacter characterController;
    protected virtual void Start()
    {
        characterController = GetComponent<BaseCharacter>();
        maxHealth = characterController.CharacterInformation.characterHP;
        currentHealth = maxHealth;
    }

    public void ReciveDamage(float damage, CharacterType type)
    {
        currentHealth -= damage;
        HealthChanged?.Invoke(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            isDead = true;
            currentHealth = 0;
            SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.explosionTankSound);
            gameObject.SetActive(false);
        }
        else
        {
            isDead = false;
        }
    }

    public virtual bool Dead()
    {
        return isDead;
    }
}
