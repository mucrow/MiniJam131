using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Timer: MonoBehaviour {
    [FormerlySerializedAs("timeText")] [SerializeField] Text timerText;

    float timeElapsed = 0f;
    bool timerIsRunning = false;

    public void StartTimer() {
        timerIsRunning = true;
    }

    void Update() {
        if (timerIsRunning) {
            timeElapsed += Time.deltaTime;
            DisplayTime(timeElapsed);
        }
    }

    void DisplayTime(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
