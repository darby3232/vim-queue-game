using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Game : MonoBehaviour
{

    public List<string> completedLevels = new List<string>();
    
    private void Start()
    {
        LoadCompletedLevels();
    }

    public void LoadCompletedLevels()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            SaveGame save = (SaveGame)bf.Deserialize(file);

            foreach (string fileName in save.levelCompleted)
                completedLevels.Add(fileName);

            file.Close();

            Debug.Log("Save Loaded");
        }
        else
        {
            Debug.Log("No Save To Load");
        }
    }

    private SaveGame CreateSaveGameObject()
    {
        SaveGame save = new SaveGame();

        foreach (string levelName in completedLevels)
            save.levelCompleted.Add(levelName);
        
        return save;
    }

    public void SaveGame()
    {
        SaveGame save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Saved game at " + Application.persistentDataPath + "/gamesave.save");
    }

    public void AddCompletedLevel(string levelName)
    {
        //check if level hasn't been completed already
        if(!completedLevels.Contains(levelName))
            completedLevels.Add(levelName);
    }

}
