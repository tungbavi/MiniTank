using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Vector2 startingTouch;
    private bool isSwiping = false;
    public bool isShooting = false;
    public static event Action<bool> OnPlayerTapScreen;

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            if (isSwiping)
            {
                Vector2 diff = Input.GetTouch(0).position - startingTouch;
                // Put difference in Screen ratio, but using only width, so the ratio is the same on both
                // axes (otherwise we would have to swipe more vertically...)
                diff = new Vector2(diff.x / Screen.width, diff.y / Screen.width);

                if (diff.magnitude > 0.01f) //we set the swip distance to trigger movement to 1% of the screen width
                {
                    if (Mathf.Abs(diff.y) > Mathf.Abs(diff.x)) // Swipe Up Or Down
                    {
                        if (diff.y < 0)
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0);
                        }
                        else
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                        }
                    }
                    else //left Or Right
                    {
                        if (diff.x < 0)
                        {
                            transform.eulerAngles = new Vector3(0, -90, 0);
                        }
                        else
                        {
                            transform.eulerAngles = new Vector3(0, 90, 0);
                        }
                    }
                    isSwiping = false;
                }
            }   

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startingTouch = Input.GetTouch(0).position;
                isSwiping = true;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                isShooting = true;
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                isSwiping = false;
                isShooting = false;
            }
            OnPlayerTapScreen?.Invoke(isShooting);
        }
    }
}
