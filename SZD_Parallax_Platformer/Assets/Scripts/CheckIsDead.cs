using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckIsDead : MonoBehaviour
{
    private int count;
    private void Start()
    {
        count = 0;
    }
    void Update()
    {
        if (count == 2)
        {
            string file = Application.dataPath + "/Value.txt";
            string[] array = File.ReadAllLines(file);
            array[6] = "false";
            File.WriteAllLines(file, array);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            count++;
        }
        
    }
}
