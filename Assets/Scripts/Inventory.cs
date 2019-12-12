using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum ItemName
    {
        Key, 
        Bomb
    }


    private int keyCount;
    private int bombCount;


    public void GainItem(ItemName itemName, int numItem)
    {
        switch (itemName)
        {
            case ItemName.Key:
                keyCount += numItem;
                break;
            case ItemName.Bomb:
                bombCount += numItem;
                break;
        }
    }
}
