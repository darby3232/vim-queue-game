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
    public Animator anim;

    public Color levelCompleted;
    public Color levelIncomplete;

    private string levelName;
    private Button levelButton;

    public void Start()
    {
        Image image = GetComponent<Image>();
        levelName = GetLevelNameByNum();

        if (game.completedLevels.Contains(levelName))
            image.color = levelCompleted;
        else
            image.color = levelIncomplete;

        //Add listener to click on button
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(() => LoadLevel());
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

    public void LoadLevel()
    {
        if (levelName == "None")
            Debug.Log("LevelNotAvailable");
        else
            StartCoroutine(LoadParticularScene(levelName));
    }

    IEnumerator LoadParticularScene(string sceneName)
    {
        anim.SetTrigger("LoadLevel");
        //Play animation first, then load
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
            yield return null;
    }
}