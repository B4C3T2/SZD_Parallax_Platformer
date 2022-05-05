using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndTime : MonoBehaviour
{
    public Text endText;
    private int score1, score2;
    // Start is called before the first frame update
    void Start()
    {
        
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Value.txt");
        sr.ReadLine();
        if (sr.ReadLine() == "TimeRush")
        {
            sr.Close();
            string file = Application.persistentDataPath + "/Value.txt";
            StreamReader sr2 = new StreamReader(file);
            endText.text = "Your time: " + TimeSpan.FromSeconds(double.Parse(sr2.ReadLine())).ToString("mm':'ss");
            sr2.Close();
        }
        else
        {
            StreamReader srScore = new StreamReader(Application.persistentDataPath + "/Value.txt");
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
