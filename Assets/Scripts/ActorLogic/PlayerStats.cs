using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    /* Timer Variables */
    private float timer;
    private bool timerStarted;
    
    /* Step Count Variables */
    private int stepCount;

    void Start()
    {
        stepCount = 0;
        timerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
            timer += Time.deltaTime;
    }
    
    public void StartTimer()
    {
        timerStarted = true;
    }

    public float GetTime()
    {
        return timer;
    }

    public void AddStep()
    {
        stepCount++;
    }

    public int GetStepCount()
    {
        return stepCount;
    }
}
