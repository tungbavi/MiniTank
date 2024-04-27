using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class BaseCharacterShooting : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] protected BaseBullet bulletPrefab;
    [SerializeField] protected Transform holderBullet;
    [SerializeField] protected Transform shootTransform;
    [SerializeField] protected BaseCharacter baseCharacter;

    protected CharacterSO character;
    public CharacterSO CharacterSO { get { return character; } }

    [Space, Header("VFX")]
    [SerializeField] protected ParticleSystem smoke;
    protected List<GameObject> bulletsList = new List<GameObject>();
    [Space, Header("Properties")]
    [SerializeField] protected int numberBullet;
    [Space, Header("Time")]
    [SerializeField] protected float timeDelayMax;
    protected float timeDelay;
    [Space, Header("Damage")]
    [SerializeField] protected float damage;

    protected virtual void Start()
    {
        //PoolingObject.Instance.addPool(bulletPrefab.gameObject, bulletsList, 20, holderBullet);
        //timeDelay = timeDelayMax;
        //character = baseCharacter.CharacterInformation;
    }

    protected virtual void Update()
    {
        timeDelay -= Time.deltaTime;
    }

    public abstract void CharacterShooting();
}
