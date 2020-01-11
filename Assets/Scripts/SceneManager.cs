using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    private List<Bomb> bombs = new List<Bomb>();

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

            //Add additional movement types here


        }
    }

    public void AddBomb(Bomb bomb)
    {
        bombs.Add(bomb);
    }

    private void UpdateBombs()
    {
        bombs.RemoveAll(Bomb => Bomb == null);

        foreach(Bomb bomb in bombs)            
            bomb.Tick();
    }

}
