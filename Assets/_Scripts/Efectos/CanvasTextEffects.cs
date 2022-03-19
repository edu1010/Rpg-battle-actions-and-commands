using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTextEffects : MonoBehaviour
{
    Text UItext;

    Color red = new Color(225, 0, 0, 225);
    Color green = new Color(0, 225, 0, 225);
    Color yellow = new Color(225, 225, 0, 225);

    public float timerHideText = 0.0f;
    public bool hideText = false;

    string signShow = "-";

    void Update()
    {
        if (hideText)
        {
            timerHideText += Time.deltaTime;
            if (timerHideText >= 1.0f)
            {
                HideText();
            }
        }
    }

    public void ShowText(GameObject entity, string textToWrite, float sign)
    {
        UItext = entity.GetComponentInChildren<Text>();
        if (sign > 0)
        {
            UItext.color = green;
            signShow = "+";
        }
        else if (sign == 0)
        {
            UItext.color = yellow;
            signShow = "+";
        }
        else
        {
            UItext.color = red;
        }

        UItext.text = signShow + textToWrite;
        hideText = true;
    }

    public void HideText()
    {
        UItext.color = new Color(0, 0, 0, 0); //invisible
        hideText = false;
        timerHideText = 0.0f;
    }
}
