using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTile : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            EndLevel();
    }

    private void EndLevel()
    {
        Debug.Log("End Level Sucker");
    }
}
