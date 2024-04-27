using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [Header("Bullet Prperties")]
    [SerializeField] protected float bulletSpeed;
    [Space, Header(("Effect"))]
    [SerializeField] protected LayerMask activeEffect;
    [SerializeField] protected float radiusEffect;
    [Space, Header("Reference")]
    public BaseCharacterShooting characterShooting;

    protected abstract void BulletMoving();

    protected virtual void SpawnFX(Transform positionCollider, Collider colliderAffect,List<GameObject> effectList)
    {
        var effect = PoolingObject.Instance.GetPoolingobj(effectList);
        effect.transform.position = positionCollider.position;
        effect.SetActive(colliderAffect);
        effect.GetComponent<ParticleSystem>().Play();
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageable iDamageable))
        {
            iDamageable = collider.GetComponent<IDamageable>();
            if (collider.GetComponent<BaseCharacterShooting>() != null)
            {
                if (collider.GetComponent<BaseCharacterShooting>().CharacterSO.characterType == characterShooting.CharacterSO.characterType) return;
            }
            if (iDamageable != null)
            {
                iDamageable.ReciveDamage(characterShooting.CharacterSO.characterDamage);
                SpawnFX(transform, collider, EffectController.Instance.GetListEffectHit());
                gameObject.SetActive(false);
            }
        }
        SpawnFX(transform,collider, EffectController.Instance.GetListEffectHit());
        gameObject.SetActive(false);
    }
}
