using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelsMenu : MonoBehaviour
{
    
    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadParticularScene(levelName));

    }


    IEnumerator LoadParticularScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
            yield return null;
    }
}
