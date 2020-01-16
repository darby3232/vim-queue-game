using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{

    public bool TryToUnlock(Player player)
    {
        if (player.TryUseKey())
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }

}
