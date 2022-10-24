using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(timerManager.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(timerManager.gameObject);
        }
        
    }

    public void Start()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Value.txt");
        sr.ReadLine();
        if(sr.ReadLine() == "TimeRush")
        {
            sr.Close();
            TimerStarted();
        }
            
        
        //timerManager.text = string.Format("Timer: " + TimeSpan.FromSeconds(elapsedTime).ToString("mm':'ss"));

    }

    public void TimerStarted()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Value.txt");
        timerIsCounting = true;
        elapsedTime = double.Parse(sr.ReadLine());
        sr.Close();
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
            string timeString = "Timer: " + time.ToString("mm':'ss");
            string file = Application.dataPath + "/Value.txt";
            string[] array = System.IO.File.ReadAllLines(file);
            array[0] = elapsedTime.ToString();
            System.IO.File.WriteAllLines(file, array);
            timerManager.text = timeString;

            yield return null;
        }
    }
    public void Update()
    {
        
    }
}
