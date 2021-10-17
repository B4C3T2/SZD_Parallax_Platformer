using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // a következő indexű scene-t tölti be
    }
    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
