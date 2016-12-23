using UnityEngine;
using System.Collections;

public class RaceStart : MonoBehaviour {

    Countdown countdown;
    RaceState raceState;

	// Use this for initialization
	void Start () {
        raceState = this.GetComponent<RaceState>();
        countdown = GameObject.Find("ManagerUI").GetComponent<Countdown>();

        StartRace();
	}
	
    /// <summary>
    /// Starts the race by changing the state
    /// </summary>
    /// <returns>Change of state</returns>
    IEnumerator StandingBy() {

        //STANDING BY
        Debug.Log("Loading assets, standing by");
        raceState.CurrentState = Gamestate.standby;
        yield return new WaitForSeconds(5.0f);

        //Change state
        //COUNTDOWN
        Debug.Log("Counting down");
        countdown.StartCountdown();
    }

    /// <summary>
    /// Standing by. Starts race afterwards
    /// </summary>
    void StartRace() {
        StartCoroutine(StandingBy());
    }
}
