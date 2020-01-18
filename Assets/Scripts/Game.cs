using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Game : MonoBehaviour
{

    List<int> completedLevels = new List<int>();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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

        Debug.Log("Saved game at " + Application.persistentDataPath + "/gamesave.save");
    }

    public void AddCompletedLevel(int levelNumber)
    {
        //check if level hasn't been completed already
        if(!completedLevels.Contains(levelNumber))
            completedLevels.Add(levelNumber);
    }

}
