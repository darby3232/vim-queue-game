using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{

    private List<LitBomb> bombs = new List<LitBomb>();

    public void UpdateScene()
    {
        UpdateEnemies();
        UpdateBombs();
    }

    private void UpdateEnemies()
    {
        //get all those w/ an enemy tag and tell them to move 
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            LinearPatrol lp = enemy.GetComponent<LinearPatrol>();
            if(lp != null)
            {
                lp.Move();
                continue;
            }

            //Add additional movement types here ???


        }
    }

    public void SwitchEnemyDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            LinearPatrol lp = enemy.GetComponent<LinearPatrol>();
            if (lp != null)
            {
                lp.SwitchDirection();
                continue;
            }
        }
    }

    public void AddBomb(LitBomb bomb)
    {
        bombs.Add(bomb);
    }

    private void UpdateBombs()
    {
        bombs.RemoveAll(Bomb => Bomb == null);

        foreach(LitBomb bomb in bombs)            
            bomb.Tick();
    }

}
