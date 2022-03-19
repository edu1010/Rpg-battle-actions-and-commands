
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Entity : MonoBehaviour,IEntity
{    
    HealthSystem HpSystem;
    public int AttackPoints = 1;
    public int HealthkPoints = 1;//Cuanto te puedes llegar a  curar usando magia de curación 
    public Team team = Team.Allies;//Por defecto son aliados
    public float speed = 15f;
    public float currentSpeed = 15f;//Velocidad actual
    public int speedToGive = 1; //Velocidad que puedes dar a quién quieras
    public bool turnFinish = false;
    public EnumEntities animal;
    EntityApearence _entityApearance;
    CanvasTextEffects _canvasTextEffects;

    private void Awake()
    {
        HpSystem = GetComponent<HealthSystem>();
        WhatAmI();
        _entityApearance = GetComponent<EntityApearence>();
        _canvasTextEffects = GetComponent<CanvasTextEffects>();
        currentSpeed = speed;
    }
    public void TakeDamage(int amount)
    {
        _entityApearance.ColorRed();
        _canvasTextEffects.ShowText(gameObject, amount.ToString(), -1);
        HpSystem.TakeDamage(amount);
    }
    public void Heal(int amount)//curarse
    {
        _entityApearance.ColorGreen();
        _canvasTextEffects.ShowText(gameObject, amount.ToString(), +1);
        //var temp = Random.Range(1, amount+1);//No siempre nos curamos la cantidad maxima
        HpSystem.TakeDamage(-amount);
    }

    public void SpeedUp(int amount)
    {
        _entityApearance.ColorYellow();
        _canvasTextEffects.ShowText(gameObject, amount.ToString(), 0);
        currentSpeed += amount;
    }

    public bool IamAlive()
    {
        return HpSystem.isAlive();
    }
    public void ReturnToLife()
    {
        HpSystem.IRevived();
    }
    public virtual void WhatAmI()
    {
        animal = EnumEntities.DinosaurRed;
    }
    
}
