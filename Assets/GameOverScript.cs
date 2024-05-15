using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public void Setup()
    {
      gameObject.SetActive(true);
    }
    public void Restart() {
        SceneManager.LoadScene("MainScene");
        Count.over = false;
    }
    public void Exit() {
        SceneManager.LoadScene("MainMenu");
        Count.over = false;
    }
}
