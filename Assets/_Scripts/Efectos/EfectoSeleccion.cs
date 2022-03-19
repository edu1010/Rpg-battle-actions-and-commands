using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSeleccion : MonoBehaviour
{
    public static void select()
    {
        deselecionarTodo();
        Entity[] entities = EntityManager.GetEntitiesAlive();
        
        foreach (var e in entities)
        {

            if (e.GetComponent<TargetSelcionado>().selecionado)
            {
                e.GetComponent<TargetSelcionado>().hand.SetActive(true);
            }
        }
        
    }
    public static void deselecionarTodo()
    {
        GameObject hands = GameObject.Find("hands");
        for( int i = 0;i < hands.transform.childCount; i++)
        {
            GameObject temp = hands.transform.GetChild(i).gameObject;
            temp.SetActive(false);
        }
      


    }
}
