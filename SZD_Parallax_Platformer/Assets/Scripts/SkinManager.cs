using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr1;
    public SpriteRenderer sr2;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin1 = 0;
    private int selectedSkin2 = 0;
    public GameObject playerskin1;
    public GameObject playerskin2;
    public static int P1Id;
    public static int P2Id;
    
    
    public void NextButton1()
    {
        selectedSkin1 = selectedSkin1 + 1;
        if (selectedSkin1 == skins.Count)
        {
            selectedSkin1 = 0;
        }
        sr1.sprite = skins[selectedSkin1];
    }
    public void PreviousButton1()
    {
        selectedSkin1 = selectedSkin1 - 1;
        if (selectedSkin1 < 0)
        {
            selectedSkin1 = skins.Count - 1;
        }
        sr1.sprite = skins[selectedSkin1];
    }

    public void NextButton2()
    {
        selectedSkin2 = selectedSkin2 + 1;
        if (selectedSkin2 == skins.Count)
        {
            selectedSkin2 = 0;
        }
        sr2.sprite = skins[selectedSkin2];
    }
    public void PreviousButton2()
    {
        selectedSkin2 = selectedSkin2 - 1;
        if (selectedSkin2 < 0)
        {
            selectedSkin2 = skins.Count - 1;
        }
        sr2.sprite = skins[selectedSkin2];
    }

    public void PlayGameFaceToFace()
    {
        if (selectedSkin1 != selectedSkin2)
        {
            P1Id = selectedSkin1 + 1;
            P2Id = selectedSkin2 + 1;
            PrefabUtility.SaveAsPrefabAsset(playerskin1, "Assets/Prefabs/selectedskin1.prefab");
            PrefabUtility.SaveAsPrefabAsset(playerskin2, "Assets/Prefabs/selectedskin2.prefab");
            string file = Application.persistentDataPath + "/Value.txt";
            string[] array = System.IO.File.ReadAllLines(file);
            array[1] = "FaceToFace";
            System.IO.File.WriteAllLines(file, array);

            SceneManager.LoadScene("Level1");
        }       
    }
    public void PlayGameTimeRush()
    {
        if (selectedSkin1 != selectedSkin2)
        {
            P1Id = selectedSkin1 + 1;
            P2Id = selectedSkin2 + 1;
            PrefabUtility.SaveAsPrefabAsset(playerskin1, "Assets/Prefabs/selectedskin1.prefab");
            PrefabUtility.SaveAsPrefabAsset(playerskin2, "Assets/Prefabs/selectedskin2.prefab");
            string file = Application.persistentDataPath + "/Value.txt";
            string[] array = System.IO.File.ReadAllLines(file);
            array[1] = "TimeRush";
            System.IO.File.WriteAllLines(file, array);

            SceneManager.LoadScene("Level1");
        }
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
