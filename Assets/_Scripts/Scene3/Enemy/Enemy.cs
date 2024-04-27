using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter
{
    [SerializeField] Rigidbody enemyRigidbody;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    public override void CharacterMovement()
    {
        Vector3 moveDirection = transform.forward * CharacterInformation.characterSpeed;
        enemyRigidbody.velocity = moveDirection;
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }
}
