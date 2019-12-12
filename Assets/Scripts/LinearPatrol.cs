using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPatrol : MonoBehaviour
{
    public enum PatrolDirection
    {
        VERTICAL, 
        HORIZONTAL
    }

    public PatrolDirection patrolDirection;

    //public float timeBetweenMoves;

    public bool patrolInifinitely; 
    public int patrolDistance;

    public bool positiveMoveDirection;

    private bool currPositiveMoveDirection;
    private int currSteps;
    private Enemy enemy;
    private int stepCount;

    public void Start()
    {
        enemy = GetComponent<Enemy>();
        currPositiveMoveDirection = positiveMoveDirection;
    }
    

    public void Move()
    {
        if (stepCount == enemy.buttonPressesPerMove)
        {
            if (patrolDirection == PatrolDirection.HORIZONTAL)
                MoveHorizontal();
            else
                MoveVertical();

            stepCount = 0;
        }
        else
        {
            stepCount++;
        }        
    }


    private void MoveHorizontal()
    {
        //detect collision
        Vector2 rayDir;
        if (currPositiveMoveDirection)
            rayDir = Vector2.right;
        else
            rayDir = Vector2.left;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, rayDir, 1.0f);

        if (ray.collider != null)
        {
            currPositiveMoveDirection = !currPositiveMoveDirection;
        }
        else if(!patrolInifinitely && currSteps < 0)
        {
            currPositiveMoveDirection = !currPositiveMoveDirection;
            currSteps = patrolDistance;
        }

        if (currPositiveMoveDirection)
            transform.Translate(new Vector3(1, 0, 0));
        else
            transform.Translate(new Vector3(-1, 0, 0));
    }

    private void MoveVertical()
    {
        //detect collision
        Vector2 rayDir;
        if (currPositiveMoveDirection)
            rayDir = Vector2.up;
        else
            rayDir = Vector2.down;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, rayDir, 1.0f);

        if (ray.collider != null)
        {
            currPositiveMoveDirection = !currPositiveMoveDirection;
        }
        else if (!patrolInifinitely && currSteps < 0)
        {
            currPositiveMoveDirection = !currPositiveMoveDirection;
            currSteps = patrolDistance;
        }

        if (currPositiveMoveDirection)
            transform.Translate(new Vector3(0, 1, 0));
        else
            transform.Translate(new Vector3(0, -1, 0));
    }

}
