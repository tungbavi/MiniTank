using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class BaseCharacter : MonoBehaviour
{
    [Header("Character Properties")]
    [SerializeField] protected CharacterSO characterInfor;
    protected Vector2 startTouchPosition;
    protected Vector2 endTouchPosition;
    protected Vector3 swipeDirection;
    public bool canMove;

    public CharacterType characterType;

    public abstract void CharacterMovement();

    public CharacterSO CharacterInformation { get { return characterInfor; } }

    protected void DetectSwipe()
    {
        canMove = true;
        swipeDirection = endTouchPosition - startTouchPosition;

        if (swipeDirection.magnitude < 50) return;
        swipeDirection.Normalize();
        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            swipeDirection = new Vector3(swipeDirection.x, 0, 0);
        }
        else
        {
            swipeDirection = new Vector3(0, 0, swipeDirection.y);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canMove = false;
    }
}
