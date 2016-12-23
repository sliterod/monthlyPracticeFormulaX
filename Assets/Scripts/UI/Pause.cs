using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseUI;
    RaceState raceState;
    bool isGamePaused;

	// Use this for initialization
	void Start () {
        raceState = GameObject.Find("Gamestate")
            .GetComponent<RaceState>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) &&
            raceState.CurrentState != Gamestate.results &&
            raceState.CurrentState != Gamestate.standby) {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Q) && isGamePaused) {
            QuitGame();
        }
	}

    /// <summary>
    /// Toggle pause status
    /// </summary>
    void TogglePause() {
        if (isGamePaused)
        {
            Time.timeScale = 1.0f;
            pauseUI.SetActive(false);
            isGamePaused = false;

            raceState.CurrentState = Gamestate.pause;
        }
        else
        {
            Time.timeScale = 0.0f;
            pauseUI.SetActive(true);
            isGamePaused = true;

            raceState.CurrentState = Gamestate.race;
        }
    }

    void QuitGame() {
#if UNITY_EDITOR
        Debug.Log("bye");
        EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
