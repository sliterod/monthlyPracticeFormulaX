using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

    float lifeTurboUse;
    float lifePitStop;
    float lifeBumping;
    float lifeCrash;

    float remainingLife;

    public float LifeTurboUse
    {
        get
        {
            return lifeTurboUse;
        }

        set
        {
            lifeTurboUse = value;
        }
    }

    public float LifePitStop
    {
        get
        {
            return lifePitStop;
        }

        set
        {
            lifePitStop = value;
        }
    }

    public float LifeBumping
    {
        get
        {
            return lifeBumping;
        }

        set
        {
            lifeBumping = value;
        }
    }

    public float LifeCrash
    {
        get
        {
            return lifeCrash;
        }

        set
        {
            lifeCrash = value;
        }
    }

    public float RemainingLife
    {
        get
        {
            return remainingLife;
        }

        set
        {
            remainingLife = value;
        }
    }

    // Use this for initialization
    void Start() {
        InitialiseValues();
    }

    /// <summary>
    /// Initialises life values
    /// </summary>
    void InitialiseValues() {
        LifeTurboUse = 0.125f;
        LifePitStop = 0.01f;
        LifeBumping = 0.15f;
        LifeCrash = 0.20f;
        RemainingLife = 1.0f;
    }
    
    /// <summary>
    /// Increases remaining life total.
    /// Updates UI.
    /// </summary>
    /// <param name="value">Amount of life to be added</param>
    public void IncreaseLife(float value) {
        RemainingLife += value;

        if (RemainingLife <= 1.0f)
        {
            GameObject.Find("ManagerUI")
                .GetComponent<LifeBar>()
                .IncreaseLife(value);
        }
        else
        {
            GameObject.Find("ManagerUI")
                .GetComponent<LifeBar>()
                .IncreaseLife(value);
            Debug.Log("Life maxed out");
        }
    }

    /// <summary>
    /// Increases remaining life total using life
    /// data with a switch.
    /// Updates UI.
    /// </summary>
    /// <param name="lifeData">Type of life to be increased</param>
    public void IncreaseLife(LifeData lifeData) {
        switch (lifeData) {
            case LifeData.pitStop:
                IncreaseLife(LifePitStop);
                break;
        }
    }

    /// <summary>
    /// Decreases life of player.
    /// Sends message to update UI.
    /// </summary>
    /// <param name="value">Total amount of life to sustract</param>
    public void DecreaseLife(float value) {

        RemainingLife -= value;

        if (RemainingLife > 0.0f)
        {
            GameObject.Find("ManagerUI")
                .GetComponent<LifeBar>()
                .DecreaseLife(value);
        }
        else {
            GameObject.Find("ManagerUI")
                .GetComponent<LifeBar>()
                .DecreaseLife(value);
            Debug.Log("Ship totalled");
        }
    }

    /// <summary>
    /// Decreases life of player using data with a switch.
    /// Updates UI.
    /// </summary>
    /// <param name="lifeData">Type of life to be increased</param>
    public void DecreaseLife(LifeData lifeData)
    {
        switch (lifeData)
        {
            case LifeData.turboUse:
                DecreaseLife(LifeTurboUse);
                break;

            case LifeData.crash:
                DecreaseLife(LifeCrash);
                break;

            case LifeData.bumpWall:
                DecreaseLife(LifeBumping);
                break;
        }
    }

    void Update()//Cable de prueba
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseLife(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseLife(0.1f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            IncreaseLife(0.01f);
        }
    }
}
