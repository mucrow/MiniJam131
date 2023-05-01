using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Timer: MonoBehaviour {
    [FormerlySerializedAs("timeText")] [SerializeField] Text timerText;

    public float TimeElapsed = 0f;
    bool timerIsRunning = false;

    public void StartTimer() {
        timerIsRunning = true;
    }

    public void StopTimer() {
        timerIsRunning = false;
    }

    void Update() {
        if (timerIsRunning) {
            TimeElapsed += Time.unscaledDeltaTime;
            DisplayTime(TimeElapsed);
        }
    }

    void DisplayTime(float timeToDisplay) {
        timerText.text = FormatTime(timeToDisplay);
    }

    public string FormatTime(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
