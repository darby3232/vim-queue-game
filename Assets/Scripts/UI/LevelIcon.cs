using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelIcon : MonoBehaviour
{

    public LevelManager levelManager;
    public Game game;
    public int levelNum;

    public Color levelCompleted;
    public Color levelIncomplete;

    private string levelName;

    public void Start()
    {
        Image image = GetComponent<Image>();
        levelName = GetLevelNameByNum();

        if (game.completedLevels.Contains(levelName))
            image.color = levelCompleted;
        else
            image.color = levelIncomplete;
    }

    private string GetLevelNameByNum()
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
