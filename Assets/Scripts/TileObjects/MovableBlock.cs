using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour
{

    public bool AcceptCollision(Vector2 direction)
    {
        //check that the block can move in that direction
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 1.0f);

        if (ray.collider == null || ray.collider.gameObject.tag == "WalkableTile")
        {
            // do something
            transform.Translate(direction);
            return true;
        }
        return false;
    }
}
