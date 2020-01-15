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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec, .6f);

            // return if hit collides w/ something
            if (hit.collider != null)
                if (hit.collider.gameObject.tag == "UnwalkableTile")
                    return false;
            
            return true;
    }
}
