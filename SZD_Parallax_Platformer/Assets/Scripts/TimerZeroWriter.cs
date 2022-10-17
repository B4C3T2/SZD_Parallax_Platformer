using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimerZeroWriter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string file = Application.persistentDataPath + "/Value.txt";
        print("Print to: " + file);
        string[] array = File.ReadAllLines(file);
        array[0] = "0";
        array[2] = "0";
        array[3] = "0";
        File.WriteAllLines(file, array);

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
