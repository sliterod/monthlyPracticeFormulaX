using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LapLabel : MonoBehaviour {

    public Text lapLabel;

    /// <summary>
    /// Changes current lap label
    /// </summary>
    public void ChangeLapLabel(int currentLap) {
        lapLabel.text = "LAP\n" + currentLap.ToString() +"/3";
    }
}
