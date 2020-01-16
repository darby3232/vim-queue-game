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

   
    public bool positiveMoveDirection;

    public GameObject directionArrow;

    private bool currPositiveMoveDirection;
    private Enemy enemy;

    public void Start()
    {
        enemy = GetComponent<Enemy>();
        currPositiveMoveDirection = positiveMoveDirection;

        if (patrolDirection == PatrolDirection.HORIZONTAL) { 
            if (currPositiveMoveDirection)
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 270);
            else
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            if (currPositiveMoveDirection)
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 0);
            else
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    public void SwitchDirection()
    {
        if(patrolDirection == PatrolDirection.HORIZONTAL)        
            patrolDirection = PatrolDirection.VERTICAL;        
        else        
            patrolDirection = PatrolDirection.HORIZONTAL;

        UpdateArrowDirection();
    }

    public void Move()
    {      
        if (patrolDirection == PatrolDirection.HORIZONTAL)
            MoveHorizontal();
        else
            MoveVertical();

        UpdateArrowDirection();
    }

    private void UpdateArrowDirection()
    {
        if (patrolDirection == PatrolDirection.HORIZONTAL)
        {
            if (currPositiveMoveDirection)
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 270);
            else
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            if (currPositiveMoveDirection)
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 0);
            else
                directionArrow.transform.eulerAngles = new Vector3(0, 0, 180);
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

        if (ray.collider != null && ray.collider.tag == "UnwalkableTile")
        {
            currPositiveMoveDirection = !currPositiveMoveDirection;
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

        if (ray.collider != null && ray.collider.tag != "WalkableTile")
        {
            currPositiveMoveDirection = !currPositiveMoveDirection;
        }       

        if (currPositiveMoveDirection)
            transform.Translate(new Vector3(0, 1, 0));
        else
            transform.Translate(new Vector3(0, -1, 0));
    }
}
