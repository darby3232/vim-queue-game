using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitBomb : MonoBehaviour
{
    public int damage;

    private Animator anim;
    private float countdownFrameTime;
    private int currFrame = 3;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Tick()
    {
        Debug.Log("Tick");
        if (currFrame-- > 0)
            anim.SetTrigger("NextState");
        else
            Explode();
    }

    
    public void Explode()
    {
        BombCollide(Vector2.up);
        BombCollide(Vector2.down);
        BombCollide(Vector2.right);
        BombCollide(Vector2.left);

        Destroy(gameObject);
    }

    private void BombCollide(Vector2 vec)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec, 1.0f);

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                PlayerController pc = hit.collider.gameObject.GetComponent<PlayerController>();
                pc.ReceiveExplosion(vec);
            }   
            else if (hit.collider.gameObject.tag == "Actor")
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if(enemy != null)
                    enemy.ReceiveExplosion(vec);
            }
            else if (hit.collider.gameObject.tag == "Item")
            {
                MovableBlock mb = hit.collider.gameObject.GetComponent<MovableBlock>();
                if (mb != null)
                    mb.AcceptCollision(vec);
            }

        }
    }
}
