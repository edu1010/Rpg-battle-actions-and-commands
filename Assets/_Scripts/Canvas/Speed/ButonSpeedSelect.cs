using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButonSpeedSelect : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    InputManager inputs;
    public void OnPointerClick(PointerEventData eventData)
    {
        inputs.MakeSpeedUp();
    }

    
}
