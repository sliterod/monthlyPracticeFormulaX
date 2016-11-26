using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tachometer : MonoBehaviour {

    public Text tachometerSpeed;
    
    /// <summary>
    /// Changes current speed
    /// </summary>
    /// <param name="speed">Speed number</param>
    public void ChangeSpeedNumber(float speed) {

        int value = 0;
        value = Mathf.RoundToInt(speed);

        if (value >= 0 && value <= 1700)
        {
            tachometerSpeed.text = value.ToString();
        }
        else
        {
            tachometerSpeed.text = "1700";
        }
    }
}
