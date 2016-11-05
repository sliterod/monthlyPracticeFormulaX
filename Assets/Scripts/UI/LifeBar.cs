using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {

    public RectTransform lifeBar;

    /// <summary>
    /// Increases scale of object to simulate life
    /// </summary>
    /// <param name="value">Amount of life to be increased</param>
	public void IncreaseLife(float value)
    {
        Vector3 lifeBarVector = lifeBar.localScale;
        float newScaleValue = lifeBarVector.x + value;

        if (newScaleValue <= 1.0f)
        {
            lifeBar.localScale = new Vector3(   newScaleValue,
                                                lifeBarVector.y,
                                                lifeBarVector.z);
        }
        else if (newScaleValue > 1.0f)
        {
            lifeBar.localScale = new Vector3(   1.0f,
                                                lifeBarVector.y,
                                                lifeBarVector.z);
        }
    }

    /// <summary>
    /// Decreases scale of object to simultate life
    /// </summary>
    /// <param name="value"></param>
    public void DecreaseLife(float value)
    {
        Vector3 lifeBarVector = lifeBar.localScale;
        float newScaleValue = lifeBarVector.x - value;
        
        if (newScaleValue > 0.0f)
        {
            lifeBar.localScale = new Vector3(   newScaleValue,
                                                lifeBarVector.y,
                                                lifeBarVector.z);
        }
        else {
            lifeBar.localScale = new Vector3(   0.0f,
                                                lifeBarVector.y,
                                                lifeBarVector.z);
        }
    }

}
