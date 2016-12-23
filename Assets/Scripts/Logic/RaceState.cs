using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceState : MonoBehaviour {

    Gamestate currentState;
    bool isTurboEnabled;

    void Awake() {
        isTurboEnabled = false;
    }

    public Gamestate CurrentState
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }

    public bool IsTurboEnabled
    {
        get
        {
            return isTurboEnabled;
        }

        set
        {
            isTurboEnabled = value;
        }
    }
}
