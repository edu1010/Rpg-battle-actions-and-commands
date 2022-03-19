using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OpenSubmenu : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject[] desactivar;
    public void OnPointerEnter(PointerEventData eventData)
    {
        menu.SetActive(true);   
        foreach(GameObject o in desactivar)
        {
            o.SetActive(false);
        }
    }
}
