﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    [SerializeField]
    private int levelNumber;

    public LevelManager levelManager;

    public GameObject gameUI;
    public GameObject endingUI;

    private List<LitBomb> bombs = new List<LitBomb>();

    private Game game;

    private void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }
    
    public void UpdateScene()
    {
        UpdateActors();
        UpdateBombs();
    }

    private void UpdateActors()
    {
        //get all those w/ an enemy tag and tell them to move 
        GameObject[] actors = GameObject.FindGameObjectsWithTag("Actor");
        foreach(GameObject actor in actors)
        {
            LinearPatrol lp = actor.GetComponent<LinearPatrol>();
            if(lp != null)
            {
                lp.Move();
                continue;
            }

            //Add additional movement types here ???


        }
    }

    public void SwitchActorDirection()
    {
        GameObject[] actors = GameObject.FindGameObjectsWithTag("Actor");
        foreach (GameObject actor in actors)
        {
            LinearPatrol lp = actor.GetComponent<LinearPatrol>();
            if (lp != null)
            {
                lp.SwitchDirection();
                continue;
            }
        }
    }

    public void AddBomb(LitBomb bomb)
    {
        bombs.Add(bomb);
    }

    private void UpdateBombs()
    {
        bombs.RemoveAll(Bomb => Bomb == null);

        foreach(LitBomb bomb in bombs)            
            bomb.Tick();
    }


    public void EndLevel()
    {
        //show the end screen dialogue
        gameUI.SetActive(false);
        endingUI.SetActive(true);

        //save level completed
        game.AddCompletedLevel(SceneManager.GetActiveScene().name);
        game.SaveGame();
    }


    public void NextLevel()
    {
        StartCoroutine(LoadSceneByName(GetNextLevelName()));
    }
    
    public void ReturnToMenu()
    {
        StartCoroutine(LoadSceneByName(levelManager.mainMenuName));
    }

    IEnumerator LoadSceneByName(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
            yield return null;
    }

    private string GetNextLevelName()
    {
        foreach(LevelData ld in levelManager.levels)
        {
            if (ld.levelNumber == levelNumber + 1)
                return ld.levelName;
        }
        return levelManager.mainMenuName;
    }

}
