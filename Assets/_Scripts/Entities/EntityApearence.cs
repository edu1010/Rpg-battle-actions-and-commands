using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityApearence : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float timer = 0.0f;
    private bool returnToNormalColor = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (returnToNormalColor)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 1.0f)
            {
                ReturnToNormalColor();
            }         
        }
    }

    public void ColorRed()
    {
        Color col = new Color(225, 0, 0, 225);
        spriteRenderer.color = col;
        returnToNormalColor = true;
    }
    public void ColorGreen()
    {
        Color col = new Color(0, 225, 0, 225);
        spriteRenderer.color = col;
        returnToNormalColor = true;
    }

    public void ColorYellow()
    {
        Color col = new Color(225, 225, 0, 225);
        spriteRenderer.color = col;
        returnToNormalColor = true;
    }

    public void ReturnToNormalColor()
    {
        Color col = new Color(225, 225, 225, 225);
        spriteRenderer.color = col;

        returnToNormalColor = false;
        timer = 0.0f;
    }
}
