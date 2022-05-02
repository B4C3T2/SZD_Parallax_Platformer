using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimerZeroWriter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string file = Application.persistentDataPath + "/Value.txt";
        print("Print to: " + file);
        StreamWriter sw = new StreamWriter(file);
        sw.Write("0");
        sw.Close();
    }
}
