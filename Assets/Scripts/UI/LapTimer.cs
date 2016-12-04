using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class LapTimer : MonoBehaviour {

    public Text timer;
    public Text bestLap;

    /// <summary>
    /// Updates current lap timer
    /// </summary>
    /// <param name="time">Total amount of time</param>
    public void UpdateTimer(float time) {
        timer.text = FormatTime(time);
    }

    /// <summary>
    /// Displays the best lap of the race
    /// </summary>
    /// <param name="time">Lap time</param>
    /// <param name="lap">Best lap</param>
    public void DisplayBestLap(float time) {
        bestLap.text = "BEST: [" + FormatTime(time) + "]";
    }

    /// <summary>
    /// Returns the time in a readable race-like time display
    /// </summary>
    /// <param name="time">Time (as seconds/milliseconds)</param>
    /// <returns>Time formatted</returns>
    public string FormatTime(float time) {
        string timeFormatted;
        string milliseconds;

        milliseconds = time.ToString("0.00");

        timeFormatted = Mathf.Floor(time / 60).ToString("00") + "'" +
                        Mathf.Floor(time % 60).ToString("00") + "\"" +
                        milliseconds.Substring(milliseconds.Length - 2);

        return timeFormatted;
    }

}
