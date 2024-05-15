using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField]  float timerTime = 60;
    [SerializeField] SpriteRenderer chton1;
    [SerializeField] SpriteRenderer chton2;
    [SerializeField] SpriteRenderer chton3;
    public GameOverScript gameOverScript;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    public void gameOver()
    {
        gameOverScript.Setup();
        Count.count = 12;
        Count.over = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerTime < 46) chton1.color = new Color(1f, 1f, 1f, 1f);

        if (timerTime < 31) { 
            chton1.color = new Color(1f, 1f, 1f, 0f); 
            chton2.color = new Color(1f, 1f, 1f, 1f);
        }

        if (timerTime < 16)
        {
            chton2.color = new Color(1f, 1f, 1f, 0f);
            chton3.color = new Color(1f, 1f, 1f, 1f);
        }

        if (timerTime > 0) timerTime -= Time.deltaTime;

        else if (timerTime < 0) { 
            timerTime = 0; 
            gameOver(); 
        }
        int minutes = Mathf.FloorToInt(timerTime / 60);
        int seconds = Mathf.FloorToInt(timerTime % 60);
       
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
