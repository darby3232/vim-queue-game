using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject keyIcon;
    public GameObject bombIcon;

    private bool hasKey;
    private bool hasBomb;    

    public void GetKey()
    {
        hasKey = true;
        keyIcon.SetActive(true);
    }

    public bool TryUseKey()
    {
        if (hasKey)
        {
            hasKey = false;
            keyIcon.SetActive(false);
            return true;
        }
        else
            return false;

    }
    
    public void GetBomb()
    {
        hasBomb = true;
        bombIcon.SetActive(true);
    }

    public bool TryUseBomb()
    {
        if (hasBomb)
        {
            hasBomb = false;
            //Update UI
            bombIcon.SetActive(false);
            return true;
        }
        else
            return false;
    }
}
