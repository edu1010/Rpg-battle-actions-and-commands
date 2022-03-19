using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoText : MonoBehaviour
{
    //Personaje
    public delegate void OnLifeTextDelegate(float CurrentHealth,float MaxHealth,float speed);
    public OnLifeTextDelegate OnText;

    HealthSystem health;
    Entity entity;
    private void Start()
    {
        health = GetComponent<HealthSystem>();
        entity = GetComponent<Entity>();
    }
    private void OnDisable()
    {
        OnText?.Invoke(0, health.maxHealth, entity.currentSpeed);
    }
    private void Update()
    {
        OnText?.Invoke(health.CurrentHealth,health.maxHealth,entity.currentSpeed);        
    }

}
