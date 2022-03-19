using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeText : MonoBehaviour
{  //este en el texyo 
    Text text;
    [SerializeField]
    ShowInfoText info;
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    private void OnEnable()
    {
        info.OnText += OnText;
    }

    private void OnDisable()
    {
        info.OnText -= OnText;
    }

    public void OnText(float CurrentHealth, float MaxHealth, float speed)
    {
       text.text = CurrentHealth + "/" + MaxHealth + " SPEED: " + speed;           
    }

}
