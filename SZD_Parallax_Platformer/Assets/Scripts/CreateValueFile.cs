using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateValueFile : MonoBehaviour
{
    [MenuItem("Tools/Write file")]
    public void WriteFile()
    {
        string file = Application.persistentDataPath + "/Value.txt";
        if (!File.Exists(file))
        {
            StreamWriter sw = File.AppendText(file);
            StreamWriter writer = new StreamWriter(file, true);
            writer.WriteLine("0");
            writer.WriteLine("0");
            writer.WriteLine("0");
            writer.WriteLine("0");
            writer.WriteLine("0");
            writer.WriteLine("0");
            writer.Close();
        }
    }
 
}

