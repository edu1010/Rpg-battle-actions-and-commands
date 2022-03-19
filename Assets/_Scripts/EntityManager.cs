using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EntityManager : MonoBehaviour
{
    [SerializeField] private static List<Entity> Entities;
    [SerializeField] private static List<Entity> EntitiesAlive;
    private static int _currentTargetIndex = 0;
    private static int _currentExecutorIndex = 0;
    public static Entity TargetEntity => EntitiesAlive[_currentTargetIndex];
    public static Entity ExecutorEntity => Entities[_currentExecutorIndex];
   
    private void Awake()
    {
        Entities = FindObjectsOfType<Entity>().OrderBy(x => x.team).ToList();
        
    }
    private void Start()
    {
        EntitiesAlive = GetAliveList();
    }
    public static void SetNextEntity()
    {
        _currentTargetIndex++;
        _currentTargetIndex = _currentTargetIndex % Entities.Count;
    }
    public static void swapEntities(Entity entity)//al finalizar el turno cambia el ejecutor de las acciones
    {
        for (int i=0;i< Entities.Count; i++)
        {
            if (entity == Entities[i])
            {
                _currentExecutorIndex = i;
                break;
             }
        }
    }

    public static Entity[] GetEnemies(Entity entity)// Esto obtiene los enemigos dependiendo del bando
    {
        return Entities.Where(x => x.team != entity.team).ToArray();
    }
    public static Entity[] GetEnemiesAlive(Entity entity)// Esto obtiene los enemigos vivos
    {
        return Entities.Where(x => x.team != entity.team && x.IamAlive()).ToArray();
    }
    public static List<Entity> GetAliveList()// Esto obtiene los  vivos
    {
        return Entities.Where(x => x.IamAlive()).ToList();
    }
    public static Entity[] GetAlliesAlive(Entity entity)// Esto obtiene los enemigos vivos
    {
        return Entities.Where(x => x.team == entity.team && x.IamAlive()).ToArray();
    }
    public static Entity[] GetEntitiesAlive()// Esto los vivos
    {
        return Entities.Where(x => x.IamAlive()).ToArray();
    }
    public  static void ChangeTarget(int index)
    {
        EntitiesAlive = GetAliveList();
        //Controlador por si quedan solo 2 y han matado al anterior
        
        if(_currentTargetIndex < EntitiesAlive.Count())
        {
            EntitiesAlive[_currentTargetIndex].GetComponent<TargetSelcionado>().selecionado = false;
            _currentTargetIndex += index;
        }
        else
        {
            _currentTargetIndex = 0;
        }
        
       if(EntitiesAlive.Count() - 1 < 0)
        {
            _currentTargetIndex = 0;
        }
        else
        {
            if(_currentTargetIndex > EntitiesAlive.Count()-1)
            {
                _currentTargetIndex = 0;
            }else
            if (_currentTargetIndex < 0)
            {
                _currentTargetIndex = EntitiesAlive.Count()-1 ;
            }
        }

        EntitiesAlive[_currentTargetIndex].GetComponent<TargetSelcionado>().selecionado = true;

        EfectosHandler.generarEfecto(Efecto.Seleccion);
        
    }
}
