using UnityEngine;
using System.Collections;

public class PitStop : MonoBehaviour {

    void OnCollisionStay(Collision collision) {
        Debug.Log("Pit stop, filling life bar");
        RestoreLife();
    }

    /// <summary>
    /// Restores life while staying on pit stop panel
    /// </summary>
    void RestoreLife() {
        GameObject.Find("Gamestate")
            .GetComponent<Life>()
            .IncreaseLife(LifeData.pitStop);
    }
}
