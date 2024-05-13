using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField]  float timerTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerTime > 0) timerTime -= Time.deltaTime; 
        else if (timerTime < 0) timerTime = 0;
        int minutes = Mathf.FloorToInt(timerTime / 60);
        int seconds = Mathf.FloorToInt(timerTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
