using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TopTimes : MonoBehaviour
{
    public Text firstText, secondText, thirdText;
    TimeSpan t1, t2, t3;
    string file;

    void Start()
    {
        file = Application.dataPath + "/Score.txt";
        string[] array = File.ReadAllLines(file);
        t1 = TimeSpan.FromSeconds(double.Parse(array[0]));
        firstText.text = t1.ToString("mm':'ss") + "\n" + array[3];
        t2 = TimeSpan.FromSeconds(double.Parse(array[1]));
        secondText.text = t2.ToString("mm':'ss") + "\n" + array[4];
        t3 = TimeSpan.FromSeconds(double.Parse(array[2]));
        thirdText.text = t3.ToString("mm':'ss") + "\n" + array[5];

    }
}
