using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement2D : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Vector3 TargetPosition;
    public LayerMask whatStopsMovement;
    public float AI_DirectionOffset = 5;
    bool canDo = true;
    public float waitTime = 2;
    public LayerMask IgnoreLayer;

    void Start()
    {
        movePoint.parent = null;
        TargetPosition = movePoint.position;
    }

    void Update()
    {
        if (canDo)
        {
            StartCoroutine(UpdateMovePoint());
        }

        //Handles Movement
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, moveSpeed * Time.deltaTime);


    }

    IEnumerator UpdateMovePoint()
    {
       // Debug.Log("UPdate pos");
        // Stop function from repeating
        canDo = false;

        //2. Pick Direction
        int Direction;
        Direction = Random.Range(0, 5);
        // Set which direction the AI is going
        //3. Set New MovePosition with Direction (add an offset)
        if (Direction == 0)
        {
          //  Debug.Log("Move North");
            TargetPosition.y = TargetPosition.y + AI_DirectionOffset;
            animator.SetInteger("StateCount", 5);
            StartCoroutine(ChangeState(5));
        }
        else if (Direction == 1)
        {
            //  Debug.Log("Move East");
            TargetPosition.x = TargetPosition.x + AI_DirectionOffset;
            animator.SetInteger("StateCount", 3);
            StartCoroutine(ChangeState(3));
        }
        else if (Direction == 2)
        {
            //  Debug.Log("Move South");
            TargetPosition.y = TargetPosition.y - AI_DirectionOffset;
            animator.SetInteger("StateCount", 7);
            StartCoroutine(ChangeState(7));
           
        }
        else if (Direction == 3)
        {
            //  Debug.Log("Move West");
            TargetPosition.x = TargetPosition.x - AI_DirectionOffset;
            animator.SetInteger("StateCount", 1);
            StartCoroutine(ChangeState(1));
            //    Invoke(animator.SetInt("StateCount", 2), 2);
        }
        else if (Direction == 4)
        {
          //  Debug.Log("Sleep");
        }

        yield return new WaitForSeconds(waitTime);

        canDo = true;

        // Check if AI can move in that direction
        RaycastHit2D hit = Physics2D.Raycast(transform.position, TargetPosition, AI_DirectionOffset + 2);


            Debug.DrawRay(transform.position, transform.forward, Color.green);

            if (hit.collider == null)
        {
            Debug.Log("Good to go");
        }
        else if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }

    public IEnumerator ChangeState(int stateNum)
    {
        yield return new WaitForSeconds(2);
        animator.SetInteger("StateCount", stateNum + 1);
    }
}
