using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndTime : MonoBehaviour
{
    public Text endTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string file = Application.persistentDataPath + "/Value.txt";
        StreamReader sw = new StreamReader(file);
        endTime.text = TimeSpan.FromSeconds(double.Parse(sw.ReadLine())).ToString("mm':'ss");          
        sw.Close();
    }
}
