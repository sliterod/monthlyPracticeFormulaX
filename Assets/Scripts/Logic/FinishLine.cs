using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        Debug.Log("New lap! Sending message");

        GameObject.Find("Gamestate")
            .GetComponent<Timer>()
            .ChangeLap();
    }
}
