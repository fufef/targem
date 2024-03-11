using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public void NewGame()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void ContinueGame()
    {
        
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);    
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
