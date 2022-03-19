using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosHandler : MonoBehaviour
{
    public  GameObject rayo;
    public static GameObject rayoStatic;
    static LineRenderer lineRenderer;
    //public static GameObject flecha;
    // Start is called before the first frame update
    private void Start()
    {
        rayoStatic = rayo;
    }
    public static void generarEfecto(Vector2 posInical,Vector2 posFinal, Efecto efecto)
    {
        if (efecto.Equals(Efecto.Rayo))
        {
           var currentRay = Instantiate(rayoStatic, Vector3.zero, Quaternion.identity);
            lineRenderer = currentRay.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, posInical);
            lineRenderer.SetPosition(1, posFinal);
        }
    } 
    public static void generarEfecto(Efecto efecto)
    {
        if (efecto.Equals(Efecto.Seleccion))
        {
            EfectoSeleccion.select();
        }
        if (efecto.Equals(Efecto.Shadow))
        {
            EfectShadowExecutor.activateShadow();
        }
    }

    public static void generarEfecto(Vector3 posFinal, Efecto efecto,Entity entity)
    {
        if (efecto.Equals(Efecto.MeleeAttack))
        {
            entity.GetComponent<AnimatorHandler>().run(posFinal);
                 
        }

    }

    public static void generarEfecto(Efecto efecto, Entity entity)
    {
        if (efecto.Equals(Efecto.getHurt))
        {
            entity.GetComponent<AnimatorHandler>().getHurt();
        }
        else if (efecto.Equals(Efecto.Attack))
        {
            entity.GetComponent<AnimatorHandler>().attack();
        }
    }
}
public enum Efecto
{
    Rayo,
    Flecha,
    Seleccion,
    MeleeAttack, 
    getHurt,
    Attack,
    Shadow
}