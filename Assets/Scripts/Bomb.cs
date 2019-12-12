using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdownTime;
    public int damage;

    private Animator anim;
    private float countdownFrameTime;
    private int frameCount = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        countdownFrameTime = countdownTime / frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownFrameTime < 0f)
        {
            anim.SetTrigger("NextState");
            countdownFrameTime = countdownTime / frameCount;
            frameCount--;
            if(frameCount == 0)
            {
                //Explode Bomb
                Explode();
            }
        }

        countdownFrameTime -= Time.deltaTime;
    }


    public void SetDamage(int dmg)
    {
        damage = dmg;
    }

    public void SetTime(float time)
    {
        countdownTime = time;
        countdownFrameTime = countdownTime / frameCount;
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
            // check if the thing being hit is a movable block
            if (hit.collider.gameObject.tag == "BreakableBlock")
            {
                //Break Block
                Destroy(hit.collider.gameObject);
            }
            else if(hit.collider.gameObject.tag == "Player")
            {
                Player player = hit.collider.gameObject.GetComponent<Player>();
                player.TakeDamage(damage);
            }
            else if (hit.collider.gameObject.tag == "Enemy")
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
            }
        }
    }
}
