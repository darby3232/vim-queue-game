using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{

    private List<LitBomb> bombs = new List<LitBomb>();

    public void UpdateScene()
    {
        UpdateActors();
        UpdateBombs();
    }

    private void UpdateActors()
    {
        //get all those w/ an enemy tag and tell them to move 
        GameObject[] actors = GameObject.FindGameObjectsWithTag("Actor");
        foreach(GameObject actor in actors)
        {
            LinearPatrol lp = actor.GetComponent<LinearPatrol>();
            if(lp != null)
            {
                lp.Move();
                continue;
            }

            //Add additional movement types here ???


        }
    }

    public void SwitchActorDirection()
    {
        GameObject[] actors = GameObject.FindGameObjectsWithTag("Actor");
        foreach (GameObject actor in actors)
        {
            LinearPatrol lp = actor.GetComponent<LinearPatrol>();
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
