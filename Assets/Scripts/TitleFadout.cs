using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFadout : MonoBehaviour
{
    public TimeScript timeScript;
    public int timeBeforeFading;
    public int fadeSpeed;

    private bool fadeOut = true;

    /// <summary>
    /// Manages initial game text/title fadout
    /// </summary>
    void Update()
    {
        int time = timeScript.GetTime();

        if (time > timeBeforeFading)
        {
            if (fadeOut)
            {
                Color objectColor = this.GetComponent<Text>().color;
                float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                this.GetComponent<Text>().color = objectColor;

                if (objectColor.a <= 0)
                {
                    fadeOut = false;
                    Destroy(this);
                }
            }
        }
    }
}
