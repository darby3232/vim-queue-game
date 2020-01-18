using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTile : MonoBehaviour
{

    private MySceneManager msm;

    private void Start()
    {
        msm = GameObject.Find("SceneManager").GetComponent<MySceneManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            EndLevel();
    }

    private void EndLevel()
    {
        Debug.Log("End Level Sucker");

        //save the completion
        msm.EndLevel();
    }
}
