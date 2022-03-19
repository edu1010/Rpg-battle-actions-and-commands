using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvasButtons : MonoBehaviour
{
    
    static  GameObject Botones;
    static  GameObject BotonesUndoRedo;
    public  GameObject BotonesNoS;
    public  GameObject BotonesUndoRedoNoS;
    private void Start()
    {
        Botones = BotonesNoS;
        BotonesUndoRedo = BotonesUndoRedoNoS;
    }
    public static void DesactivateCanvas()
    {
        Botones.SetActive(false);
        BotonesUndoRedo.SetActive(false);
    }
    public static void ActivateCanvas()
    {
        Botones.SetActive(true);
        BotonesUndoRedo.SetActive(true);

    }
    private void Update()
    {
        if (EntityManager.ExecutorEntity.GetComponent<IA>() != null)
        {
            ControlCanvasButtons.DesactivateCanvas();
        }
        else
        {
            ControlCanvasButtons.ActivateCanvas();
        }
    }
}
