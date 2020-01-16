using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLoadScene : MonoBehaviour
{
   
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadParticularScene(sceneName));
    }


    IEnumerator LoadParticularScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
            yield return null;
    }
}
