using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Vector2 movement;

    public void MoveAway()
    {
        transform.Translate(movement.x, movement.y, 0);
    }

    public void MoveBack()
    {
        transform.Translate(-movement.x, -movement.y, 0);
    }
}
