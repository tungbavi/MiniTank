using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField]
    private Transform holderTransform;
    private PlayerInputController playerInputController;
    private PlayerShooting PlayerShooting;
    public bool canMoveWhenCollideEnemy;

    private void Start()
    {
        canMoveWhenCollideEnemy = true;
        playerInputController = GetComponent<PlayerInputController>();
        PlayerShooting = GetComponent<PlayerShooting>();
        playerRigidbody = GetComponent<Rigidbody>();
        SpawnPlayerModel();
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    public override void CharacterMovement()
    {
        if (playerInputController.isShooting)
        {
            playerRigidbody.velocity = Vector3.zero;
            return;
        }
        if(canMoveWhenCollideEnemy)
        {
            Vector3 moveDirection = transform.forward * characterInfor.characterSpeed;
            playerRigidbody.velocity = moveDirection;
            playerRigidbody.constraints = RigidbodyConstraints.None;
            playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }
        else
        {
            playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        //playerRigidbody.MovePosition(playerRigidbody.position + moveDirection * Time.deltaTime);
    }

    public void SpawnPlayerModel()
    {
        Instantiate(PlayerData.Instance.PlayerTankModel.characterPrefab, holderTransform);
        characterInfor = PlayerData.Instance.PlayerTankModel;
    }
}
