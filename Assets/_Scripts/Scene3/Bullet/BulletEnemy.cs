using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : BaseBullet
{
    [SerializeField] private float bulletLifetime;

    private void Start()
    {
        StartCoroutine(DeactiveBullet());
    }

    IEnumerator DeactiveBullet()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(gameObject);
    }

    protected override void BulletMoving()
    {
        //throw new System.NotImplementedException();
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
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
                if (type != DestructiveType.River)
                {
                    Destroy(gameObject);
                    SpawnFX(transform, collider, EffectController.Instance.GetListEffectHit());
                    SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.explosionShellSound);
                }
            }
            else
            {
                BaseCharacterShooting characterWhoShooting = collider.GetComponent<BaseCharacterShooting>();
                if (characterWhoShooting.CharacterSO.characterType == characterShooting.CharacterSO.characterType)
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
