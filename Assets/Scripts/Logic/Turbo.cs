using UnityEngine;
using System.Collections;

public class Turbo : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Turbo booster, increase speed");
        TurboPanel();
    }

    /// <summary>
    /// Increase speed with a turbo panel
    /// </summary>
    void TurboPanel() {
        //Send message to the vehicle
    }
}
