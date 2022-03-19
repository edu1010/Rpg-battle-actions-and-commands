    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TurnManager : MonoBehaviour
{
    [SerializeField] public static Entity[] EntitiesOrder;//Orden de turnos de las entidades en funcion de su speed
    public static int indexOrder=0;
    // Start is called before the first frame update
    void Start()
    {
        EntitiesOrder = EntityManager.GetEntitiesAlive();
        OrderList();
        EntityManager.swapEntities(EntitiesOrder[0]);//En el start iniciamos el primer ejecutor en funcion de su speed, el resto se deciden al acabar turno
    }
    public static void OrderList()//Ordena la lista en funcion de la speed de los personajes
    {
        EntitiesOrder = EntityManager.GetEntitiesAlive();
        EntitiesOrder = EntitiesOrder.OrderByDescending(x => x.turnFinish == false).ThenByDescending(x => (x.currentSpeed)).ToArray();
        OrderCanvas.Order();
    }
    public static void nextTurn()
    {
        resetTurns();
        OrderList();

        EntityManager.swapEntities(EntitiesOrder[0]);
    }
    public static void resetTurns()//Vuelve a poner todos los endturn a false si es necesario
    {
        
        bool resetear = true;
        foreach (var ent in EntitiesOrder)
        {
            if (ent.turnFinish == false)
            {
                resetear = false;
            }
        }
        if (resetear)
        {
            foreach (var ent in EntitiesOrder)
            {
                ent.turnFinish = false;
            }
        }
    }
}
