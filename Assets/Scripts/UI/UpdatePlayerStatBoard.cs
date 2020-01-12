using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePlayerStatBoard : MonoBehaviour
{
    public PlayerStats ps;

    public TextMeshProUGUI timer;
    public TextMeshProUGUI stepCount;


    private int lastStepCount;

    void Start()
    {
        lastStepCount = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if(ps.GetStepCount() != lastStepCount)
        {
            lastStepCount = ps.GetStepCount();
            stepCount.text = lastStepCount.ToString();
        }

        timer.text = ps.GetTime().ToString("#.00");       
    }
}
