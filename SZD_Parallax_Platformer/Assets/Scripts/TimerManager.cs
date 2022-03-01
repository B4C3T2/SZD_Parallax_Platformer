using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    public Text timerManager;
    private TimeSpan time;
    private bool timerIsCounting;
    public bool TimerIsCounting
    {
        get { return timerIsCounting; }
    }
    private double elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        timerManager.text = "Time: 00:00";
        timerIsCounting = false;
    }

    public void TimerStarted()
    {
        timerIsCounting = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerIsCounting = false;
    }
    private IEnumerator UpdateTimer()
    {
        while (timerIsCounting)
        {
            elapsedTime += Time.deltaTime;
            time = TimeSpan.FromSeconds(elapsedTime);
            string timeString = "Time: " + time.ToString("mm':'ss");
            timerManager.text = timeString;

            yield return null;
        }
    }
    public void Update()
    {
        
    }
}
