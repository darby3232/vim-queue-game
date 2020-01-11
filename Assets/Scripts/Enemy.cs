using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public void ReceiveExplosion(Vector2 vec)
    {
        if (CanMove(vec))
            transform.Translate(vec);
    }



    private bool CanMove(Vector2 vec) { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec, /*1.0*/.6f);

            // return if hit collides w/ something
            if (hit.collider != null)
            {
                // check if the thing being hit is a movable block
                if (hit.collider.gameObject.tag == "MovableBlock")
                {
                    MovableBlock mb = hit.collider.gameObject.GetComponent<MovableBlock>();
                    mb.AcceptCollision(vec);

                }               
                else if (hit.collider.gameObject.tag == "Button" || hit.collider.gameObject.tag == "Exit")
                {
                    return true;
                }
                //if player runs into wall, don't expect it to get through the wall
                return false;
            }
            else
                return true;
    }
}
