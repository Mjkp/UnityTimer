using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerExample : MonoBehaviour, TimerListener
{

    public int[] timeInterval; // number and value of timers you want to set 
    private int initialDelay = 100;
    private int timerNum; // number of timer
    const int timerForward = 1;
    const int timerBackward = 0;

    TimerHandler[] timers;   

    private static void Main()
    {
        // main script to activate this script

    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) InitiateTimer(timerForward);
    }

    public void Awake()
    {
        init();
    }

    public void init() 
    {

        //  time intervals;
        timeInterval = new int[] { 5000,1000 };
        timerNum = timeInterval.Length;

   
        timers = new TimerHandler[timerNum];
        for (int i = 0; i < timerNum; i++)
        {
            timers[i] = new TimerHandler();
        }

        foreach (TimerHandler timer in timers)
        {
            timer.AddListener(this);
        }
    }

    public void InitiateTimer(int x)
    {
        // 0 for foward and 1 for backward
        if (x == 1)
        {
            for (int i = 0; i < timers.Length; i++)
            {
                timers[i].StartTimer(initialDelay + timeInterval[(timeInterval.Length-1) - i], "timer-" + i.ToString());
            }
        }
        else if(x ==0)
        {
            for (int i = 0; i < timers.Length; i++)
            {
                timers[i].StartTimer(initialDelay + timeInterval[i], "timer-" + i.ToString());
            }
        }
    }


    // this is the implementation function of the function declared in ITimerListener interface
    public void OnTimerComplete(object timer)
    {
        if(timer == timers[0]) Debug.Log("completed the first timer");
        if (timer == timers[1]) Debug.Log("completed the second timer");
        


    }
}
