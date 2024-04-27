using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float timeDelay;
    private float timer;
    private int[] arr = { 0, -180, -90, -270 };
    private bool movingVertical = true;
    private bool dead = false;

    private void Start()
    {
        timer = 0;
        GetComponent<BaseCharacterHealth>().HealthChanged += OnHealthChanged;
    }

    private void Update()
    {
        RandomRotateQuaternion();
    }

    private void OnHealthChanged(float maxHealth, float currentHealth)
    {
        dead = currentHealth <= 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        movingVertical = Mathf.Abs(transform.eulerAngles.y % 180) == 0f;
        Debug.Log(movingVertical);
        if (collision.gameObject.CompareTag("VisibleWall") || collision.gameObject.CompareTag("Enemy"))
        {
            float angle = 180 + transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().canMoveWhenCollideEnemy = false;
        }

        Destructive character = collision.gameObject.GetComponent<Destructive>();
        if (character != null && (character.destructiveType == DestructiveType.River || character.destructiveType == DestructiveType.Steel))
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().canMoveWhenCollideEnemy = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().canMoveWhenCollideEnemy = true;
        }
    }

    private void RandomRotateQuaternion()
    {
        timer += Time.deltaTime;
        if (timer >= timeDelay)
        {
            int index = Random.Range(movingVertical ? 2 : 0, movingVertical ? 4 : 2);
            transform.rotation = Quaternion.Euler(0, arr[index], 0);
            movingVertical = !movingVertical;
            timer = 0;
        }
    }
}
