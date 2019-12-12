using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Direction{
        UP, 
        DOWN, 
        RIGHT, 
        LEFT
    }

   
    public float speed;
    public int damage;
    public bool playerBullet;

    private Direction direction;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move forward
        switch (direction)
        {
            case Direction.UP:
                transform.Translate(0, speed * Time.deltaTime, 0);
                break;
            case Direction.DOWN:
                transform.Translate(0, -speed * Time.deltaTime, 0);
                break;
            case Direction.RIGHT:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case Direction.LEFT:
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                break;
        }
    }

    public void SetDirection(Direction dir)
    {
        direction = dir;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerBullet)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                //hit
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                //Destroy 
                Destroy(gameObject);
            }else if(collision.gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
        }
        else
        {
           if (collision.gameObject.tag == "Player")
           {
                //hit
                Player player = collision.gameObject.GetComponent<Player>();
                player.TakeDamage(damage);
                //Destroy 
                Destroy(gameObject);
           }else if (collision.gameObject.tag != "Enemy")
           {
                Destroy(gameObject);
           }
        }

    }

}
