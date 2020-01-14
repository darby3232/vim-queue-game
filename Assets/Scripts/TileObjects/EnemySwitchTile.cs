using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchTile : MonoBehaviour
{
    private MySceneManager msm; 

    public void Start()
    {
        GameObject sceneObj = GameObject.Find("SceneManager");
        if (sceneObj is null)
            Debug.LogError("No SceneManager in scene.");
        msm = sceneObj.GetComponent<MySceneManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            msm.SwitchEnemyDirection();            
    }

}
