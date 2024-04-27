using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : BaseBullet
{
    [SerializeField] private float bulletLifetime;
    private Rigidbody bulletRigidbody;

    private void Start()
    {
        StartCoroutine(DeactiveBullet());
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    IEnumerator DeactiveBullet()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(gameObject);
    }

    protected override void BulletMoving()
    {
        //transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }

    private void Update()
    {
        BulletMoving();
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageable iDamageable))
        {
            if (collider.gameObject.CompareTag("Tile"))
            {
                iDamageable.ReciveDamage(characterShooting.CharacterSO.characterDamage, characterShooting.CharacterSO.characterType);
                DestructiveType type = collider.GetComponent<Destructive>().destructiveType;
                if (type != DestructiveType.Tower && type != DestructiveType.River)
                {
                    SpawnFX(transform, collider, EffectController.Instance.GetListEffectHit());
                    SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.explosionShellSound);
                    Destroy(gameObject);
                }     
            }
            else
            {
                BaseCharacterShooting characterWhoShooting = collider.GetComponent<BaseCharacterShooting>();
                if(characterWhoShooting.CharacterSO.characterType == characterShooting.CharacterSO.characterType) 
                    return;
                if (characterWhoShooting != null && iDamageable != null)
                {
                    iDamageable.ReciveDamage(characterShooting.CharacterSO.characterDamage);
                    SpawnFX(transform, collider, EffectController.Instance.GetListEffectHit());
                    SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.explosionShellSound);
                    Destroy(gameObject);
                }
            }
        }
    }
}
