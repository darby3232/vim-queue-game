﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelsMenu : MonoBehaviour
{

    public LevelManager levelManager;

    private string GetNextLevelNameByNum(int levelNum)
    {
        foreach (LevelData ld in levelManager.levels)
        {
            if (ld.levelNumber == levelNum)
                return ld.levelName;
        }
        return "None";
    }

    public void LoadLevel(int levelNum)
    {
        string levelName = GetNextLevelNameByNum(levelNum);

        if (levelName == "None")
            Debug.Log("LevelNotAvailable");
        else
            StartCoroutine(LoadParticularScene(levelName));
    }


    IEnumerator LoadParticularScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
            yield return null;
    }
}
