using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScene()
    {
        UpdateEnemies();
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

}
