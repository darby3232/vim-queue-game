using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelManager", order = 1)]
public class LevelManager : ScriptableObject
{
    public string mainMenuName;
    public LevelData[] levels;
}

[System.Serializable]
public class LevelData
{
    public int levelNumber;
    public string levelName;
}