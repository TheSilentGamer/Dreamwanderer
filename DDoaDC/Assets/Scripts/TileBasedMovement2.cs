using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBasedMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

   public bool HorizontalIsPressed;
    public bool HorizontalDown;
    public bool VerticalIsPressed;
    public bool VerticalDown;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            if (!HorizontalDown)
            {
                HorizontalIsPressed = true;
                VerticalIsPressed = false;
                HorizontalDown = true;
            }
        }
        else
        {
            HorizontalIsPressed = false;
            HorizontalDown = false;
        }

        if (Input.GetAxisRaw("Vertical") != 0f)
        {
            if (!VerticalDown)
            {
                HorizontalIsPressed = false;
                VerticalIsPressed = true;
                VerticalDown = true;
            }
        }
        else
        {
            VerticalIsPressed = false;
            VerticalDown = false;
        }

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .1f, whatStopsMovement) && HorizontalIsPressed)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
             if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .1f, whatStopsMovement) && VerticalIsPressed)
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f); 

                }
            }
        }
    }
}
