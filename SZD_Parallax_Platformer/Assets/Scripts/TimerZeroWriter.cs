using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimerZeroWriter : MonoBehaviour
{
    void Start()
    {
        string file = Application.dataPath + "/Value.txt";
        print("Print to: " + file);
        string[] array = System.IO.File.ReadAllLines(file);
        array[0] = "0";
        array[2] = "0";
        array[3] = "0";
        System.IO.File.WriteAllLines(file,array);      
    }
}
