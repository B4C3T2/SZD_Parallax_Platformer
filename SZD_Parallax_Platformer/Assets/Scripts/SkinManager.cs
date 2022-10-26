using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

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
    public Text player1InputName;
    public Text player2InputName;
    public Text warningText;
    string file;

    private void Start()
    {
        file = Application.dataPath + "/Value.txt";
    }
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
        
        Warning();
        if ((selectedSkin1 != selectedSkin2) && (player1InputName.text.Length <= 10) && (player2InputName.text.Length <= 10))
        {
            string[] array = File.ReadAllLines(file);
            array[1] = "FaceToFace";
            File.WriteAllLines(file, array);
            ChangeSkin();
        }       
    }
    public void PlayGameTimeRush()
    {
        Warning();
        if((selectedSkin1 != selectedSkin2) && (player1InputName.text.Length <= 10) && (player2InputName.text.Length <= 10))
        {
            string[] array = File.ReadAllLines(file);
            array[1] = "TimeRush";
            File.WriteAllLines(file, array);
            ChangeSkin();
        }
    }
    void ChangeSkin()
    {
        P1Id = selectedSkin1 + 1;
        P2Id = selectedSkin2 + 1;
        PrefabUtility.SaveAsPrefabAsset(playerskin1, "Assets/Prefabs/selectedskin1.prefab");
        PrefabUtility.SaveAsPrefabAsset(playerskin2, "Assets/Prefabs/selectedskin2.prefab");
        string[] array = File.ReadAllLines(file);
        array[4] = player1InputName.text;
        array[5] = player2InputName.text;
        File.WriteAllLines(file, array);

        SceneManager.LoadScene("Level1");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Warning()
    {
        if (selectedSkin1 == selectedSkin2)
        {
            var locale = LocalizationSettings.SelectedLocale;
            Debug.Log(locale);
            if (locale.ToString() == "English (en)")
                warningText.text = "You can't use the same skin!\nPlease choose another one.";
            if (locale.ToString() == "Hungarian (hu)")
                warningText.text = "Nem használhatjátok ugyan azt a skint!\nValaki válasszon másikat.";
            if (locale.ToString() == "German (de)")
                warningText.text = "Sie können nicht denselben Skin verwenden!\nBitte wählen Sie eine andere aus.";
        }
        if ((player1InputName.text.Length > 10) || (player2InputName.text.Length > 10))
        {
            var locale = LocalizationSettings.SelectedLocale;
            if (locale.ToString() == "English (en)")
                warningText.text = "Your name is too long!\nThe maximum character size is 10.";
            if (locale.ToString() == "Hungarian (hu)")
                warningText.text = "A név túl hosszú!\nMaximum 10 karakterböl állhat.";
            if (locale.ToString() == "German (de)")
                warningText.text = "Ihr Name ist zu lang!\nDie maximale Zeichengröße beträgt 10.";
        }
    }

}
