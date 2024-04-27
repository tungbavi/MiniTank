using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : BaseCharacterShooting
{
    private void Awake()
    {
        baseCharacter = GetComponent<Enemy>();
    }

    public override void CharacterShooting()
    {
        if(timeDelay > 0) return;

        timeDelay = timeDelayMax;

        BulletEnemy bulletPlayer = (BulletEnemy)Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);
        bulletPlayer.characterShooting = this;
        bulletPlayer.transform.forward = shootTransform.forward;
        //SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.shootSound);
    }

    protected override void Start()
    {
        base.Start();
        character = baseCharacter.CharacterInformation;
    }

    protected override void Update()
    {
        base.Update();
        CharacterShooting();
    }
}
