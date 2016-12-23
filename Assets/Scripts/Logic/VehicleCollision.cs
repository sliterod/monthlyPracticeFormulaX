using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour {

    Life life;

    void Start() {
        life = GameObject.Find("Gamestate")
            .GetComponent<Life>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Collision registered: " + other.tag);

        switch (other.tag) {
            case "bump":
                Debug.Log("Bump wall. Reducing life");
                life.DecreaseLife(LifeData.bumpWall);
                break;

            case "crash":
                Debug.Log("Crash with another vehicle. Reducing life");
                life.DecreaseLife(LifeData.crash);
                break;
        }

    }
    
}
