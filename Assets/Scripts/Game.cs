using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Game : MonoBehaviour
{

    List<int> completedLevels = new List<int>();

    public void LoadCompletedLevels()
    {

    }

    private SaveGame CreateSaveGameObject()
    {
        SaveGame save = new SaveGame();

        foreach (int levelNum in completedLevels)
            save.levelCompleted.Add(levelNum);
        
        return save;
    }

    public void SaveGame()
    {
        SaveGame save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void AddCompletedLevel(int levelNumber)
    {
        completedLevels.Add(levelNumber);
    }

}
