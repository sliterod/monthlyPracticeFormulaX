using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    bool isTimerEnabled;
    float timeOnRace;
    float currentLapTime;
    int lapIndex;
    float[] lapTimes;

	// Use this for initialization
	void Start () {
        lapTimes = new float[] { 5999.999f, 5999.999f, 5999.999f };
        timeOnRace = 0.0f;
        currentLapTime = 0.0f;
        lapIndex = 0;

        ChooseBestTime();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A)) {
            isTimerEnabled = true;
        }

        if (isTimerEnabled) {
            DisplayTime();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ResetLap();
        }
    }

    /// <summary>
    /// Displays current lap time
    /// </summary>
    void DisplayTime() {

        timeOnRace = timeOnRace + Time.deltaTime;
        currentLapTime = currentLapTime + Time.deltaTime;

        GameObject.Find("ManagerUI").GetComponent<LapTimer>().UpdateTimer(timeOnRace);
    }

    /// <summary>
    /// Resets timer after lap completion
    /// </summary>
    void ResetLap() {

        SaveLapTime();

        currentLapTime = 0.0f;

        GameObject.Find("ManagerUI").GetComponent<LapTimer>().UpdateTimer(timeOnRace);
    }

    /// <summary>
    /// Saves current time in a array to display after race completion
    /// </summary>
    void SaveLapTime() {
        if (lapIndex < lapTimes.Length)
        {
            lapTimes[lapIndex] = currentLapTime;

            Debug.Log("Last lap: " + lapTimes[lapIndex]);
            ChooseBestTime();

            lapIndex += 1;

            if (lapIndex == lapTimes.Length) {
                isTimerEnabled = false;
            }
        }
    }

    /// <summary>
    /// Interrupts lap and finishes the timer update.
    /// Used in case of retire of explosion
    /// </summary>
    void LapInterruption() {
        isTimerEnabled = false;
    }

    /// <summary>
    /// Chooses best time of the array and displays it
    /// </summary>
    void ChooseBestTime() {

        float[] bestArray = lapTimes;

        System.Array.Sort(bestArray);
        GameObject.Find("ManagerUI").GetComponent<LapTimer>().DisplayBestLap(bestArray[0]);
    }
}
