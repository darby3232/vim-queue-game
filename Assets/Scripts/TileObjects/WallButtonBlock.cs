using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtonBlock : MonoBehaviour
{

    public MovingWall movingWall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movingWall.MoveAway();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        movingWall.MoveBack();
    }
}
