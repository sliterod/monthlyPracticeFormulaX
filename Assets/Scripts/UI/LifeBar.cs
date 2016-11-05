using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

    public RectTransform lifeBar;
    public Image lifeBarImage;

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

        ChangeColor(newScaleValue);
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

        ChangeColor(newScaleValue);
    }

    /// <summary>
    /// Changes the color of the life bar
    /// </summary>
    /// <param name="remainingLife">Current percentage damage</param>
    void ChangeColor(float remainingLife)
    {

        if (remainingLife > 0.0f &&
            remainingLife <= 0.3f)
        {
            lifeBarImage.color = new Color(0.67f, 0.0f, 0.0f);
        }

        if (remainingLife > 0.3f &&
            remainingLife <= 0.75f)
        {
            lifeBarImage.color = new Color(0.67f, 0.67f, 0.0f);
        }

        if (remainingLife > 0.75f)
        {
            lifeBarImage.color = new Color(0.0f, 0.67f, 0.0f);
        }
    }
}
