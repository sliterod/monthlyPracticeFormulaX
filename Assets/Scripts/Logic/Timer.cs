using UnityEngine;
using System.Collections;
using System.Linq;

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

        if (Input.GetKeyDown(KeyCode.L)) {
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
    /// Enables lap timer
    /// </summary>
    public void EnableTimer() {
        isTimerEnabled = true;
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

        if (lapIndex + 1 <= 3) { 
            GameObject.Find("ManagerUI").GetComponent<LapLabel>().ChangeLapLabel(lapIndex+1);
        }

        if (lapIndex + 1 == 2) {
            GameObject.Find("ManagerUI").GetComponent<LifeBar>().ChangeLifeBar();
        }
    }

    /// <summary>
    /// Change to a new lap
    /// </summary>
    public void ChangeLap() {
        ResetLap();
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

            if (lapIndex == lapTimes.Length)
            {
                isTimerEnabled = false;
                //Displaying Results
                GameObject.Find("ManagerUI").GetComponent<ResultsScreen>().DisplayResults(lapTimes);

                //Changing state
                this.GetComponent<RaceState>().CurrentState = Gamestate.results;
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

        float best = lapTimes.Min();
        GameObject.Find("ManagerUI").GetComponent<LapTimer>().DisplayBestLap(best);
    }
}
