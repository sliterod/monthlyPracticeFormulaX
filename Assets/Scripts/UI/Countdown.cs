using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public Text countdownText;

    /// <summary>
    /// Starts countdown coroutine
    /// </summary>
	public void StartCountdown() {
        StartCoroutine(CountdownRoutine());
	}

    IEnumerator CountdownRoutine() {

        countdownText.text = "3";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "GO!!";
        yield return new WaitForSeconds(1.5f);

        countdownText.gameObject.SetActive(false);

        ChangeToRace();
    }

    /// <summary>
    /// Changes state to race and activates lap timer
    /// </summary>
    void ChangeToRace() {
        //Change state
        GameObject.Find("Gamestate")
            .GetComponent<RaceState>()
            .CurrentState = Gamestate.race;

        //Enable Timer
        GameObject.Find("Gamestate")
            .GetComponent<Timer>()
            .EnableTimer();
    }
}
