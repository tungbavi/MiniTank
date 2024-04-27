using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    private ParticleSystem particleSystemEffect;
    [SerializeField] private float delay = 2f;

    private void Awake()
    {
        particleSystemEffect = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (gameObject.activeSelf)
            Invoke("ActivateObject", delay);
    }

    private void ActivateObject()
    {
        transform.gameObject.SetActive(false);
    }
}
