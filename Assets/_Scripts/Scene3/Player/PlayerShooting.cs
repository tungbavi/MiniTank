using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : BaseCharacterShooting
{
    private bool canShot;

    private void Awake()
    {
        PlayerInputController.OnPlayerTapScreen += HandleOnPlayerTapScreen;
        baseCharacter = GetComponent<Player>();
    }

    protected override void Start()
    {
        base.Start();
        character = baseCharacter.CharacterInformation;
    }

    private void OnDestroy()
    {
        PlayerInputController.OnPlayerTapScreen -= HandleOnPlayerTapScreen;
    }

    private void HandleOnPlayerTapScreen(bool obj)
    {
        canShot = obj;
    }

    public override void CharacterShooting()
    {
        //throw new System.NotImplementedException();
        if(canShot && timeDelay <= 0)
        {
            BulletPlayer bulletPlayer = (BulletPlayer)Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);
            bulletPlayer.characterShooting = this;
            bulletPlayer.transform.forward = shootTransform.forward;
            SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.shootSound);
            timeDelay = timeDelayMax;
        }
    }

    protected override void Update()
    {
        base.Update();

        CharacterShooting();
    }
}
