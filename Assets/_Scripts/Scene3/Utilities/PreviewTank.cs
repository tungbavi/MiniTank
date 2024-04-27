using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewTank : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 15;
    private float angle;
    private void Start()
    {
        angle = transform.eulerAngles.y;
    }
    void Update()
    {
        angle += rotateSpeed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
