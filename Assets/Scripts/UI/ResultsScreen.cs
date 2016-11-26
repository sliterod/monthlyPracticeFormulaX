using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class ResultsScreen : MonoBehaviour {

    public GameObject resultsScreen;
    public Text laps;
    public Text raceTotal;
    LapTimer lapTimer;

    void Start() {
        lapTimer = this.GetComponent<LapTimer>();
    }

    /// <summary>
    /// Displays results screen
    /// </summary>
    /// <param name="timer">Array with race times</param>
    public void DisplayResults(float[] timer) {
        
        float totalTime;

        //Setting totals
        totalTime = timer[0] + timer[1] + timer[2];

        resultsScreen.SetActive(true);

        //Choosing best time
        FindBestTimeIndex(timer);

        //Total time
        raceTotal.text = 
            "___________________________\n"+
            "TOTAL: " +
            lapTimer.FormatTime(totalTime);
    }

    /// <summary>
    /// Finds the best lap.
    /// Locates all lap times on their respective
    /// UI texts
    /// </summary>
    /// <param name="timer">Array with race times</param>
    void FindBestTimeIndex(float[] timer) {
        int index = 0;
        float best = 0;

        //Best lap
        best = timer.Min();

        for (int i = 0; i < timer.Length; i++) {
            if (timer[i] == best) {
                index = i;
            }
        }

        //Setting text on Labels
        SetLapResults(timer, index);
    }

    /// <summary>
    /// Sets results with the best lap in green color
    /// </summary>
    /// <param name="lapTimes">Array with laps</param>
    /// <param name="index">Index location of the best lap</param>
    void SetLapResults(float[] lapTimes, int index)
    {
        string lapResults = "";

        for (int i = 0; i < lapTimes.Length; i++)
        {
            if (i == index)
            {
                lapResults = lapResults +
                    "<color=\"#008000ff\">" +
                    lapTimer.FormatTime(lapTimes[i]) +
                    "</color>"+
                    "\n";
            }
            else {
                lapResults = lapResults + lapTimer.FormatTime(lapTimes[i]) + "\n";
            }
        }

        laps.text = lapResults;
    }
}
