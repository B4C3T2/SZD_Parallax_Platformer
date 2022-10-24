using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndTime : MonoBehaviour
{
    public Text endText;
    public double tempTime;
    private int score1, score2;
    void Start()
    {
        

       
        StreamReader sr = new StreamReader(Application.dataPath + "/Value.txt");
        sr.ReadLine();
        if (sr.ReadLine() == "TimeRush")
        {
            sr.Close();
            string file = Application.dataPath + "/Value.txt";
            StreamReader sr2 = new StreamReader(file);
            TimeSpan t = TimeSpan.FromSeconds(double.Parse(sr2.ReadLine()));
            endText.text = "Your time: " + t.ToString("mm':'ss");
            sr2.Close();
            tempTime = double.Parse(t.Seconds.ToString());
            TimerManager time = new TimerManager();
            time.EndTimer();
        }
        else
        {
            StreamReader srScore = new StreamReader(Application.dataPath + "/Value.txt");
            srScore.ReadLine();
            srScore.ReadLine();
            score1 = int.Parse(srScore.ReadLine());
            score2 = int.Parse(srScore.ReadLine());
            if (score1 > score2)
                endText.text = "P1 won the game, scored: " + score1 + ":" + score2;
            else if (score1 < score2)
                endText.text = "P2 won the game, scored: " + score2 + ":" + score1;
            else
                endText.text = "It's a tie! Scores: " + score2 + ":" + score1;

        }
        
        string times = Application.dataPath + "/Score.txt";
        string[] array = File.ReadAllLines(times);
        string file2 = Application.dataPath + "/Value.txt";
        string[] array2 = File.ReadAllLines(file2);

        if (tempTime < double.Parse(array[0]))
        {
            array[2] = array[1];
            array[1] = array[0];       
            array[0] = tempTime.ToString();
            array[3] = array2[4] + " & " + array2[5];
        }
        else if (tempTime < double.Parse(array[1]) && tempTime > double.Parse(array[0]))
        {
            array[2] = array[1];
            array[1] = tempTime.ToString();
            array[4] = array2[4] + " & " + array2[5];
        }
        else if (tempTime < double.Parse(array[2]) && tempTime > double.Parse(array[1]))
        {
            array[2] = tempTime.ToString();
            array[5] = array2[4] + " & " + array2[5];
        }
        File.WriteAllLines(times, array);
    }

   
}
