using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDelegate : MonoBehaviour
{
    public GameObject deathEffect;
    private GameObject effect;

    private HealthSystem health;
    private Entity entity;
    int counter = 0;//Diferenciar el primer enable de revivir
    public void Awake()
    {
        health = GetComponent<HealthSystem>();
        entity = GetComponent<Entity>();
    }
    private void OnEnable()
    {
        health.OnDeath += OnDeath;
        if (counter == 0) 
        {
            counter += 1;
        }
        else
        {
            OrderCanvas.animalRevive(entity.animal);
            if (effect != null)
            {
                Destroy(effect);
            }
        }
        
        

    }
    private void OnDisable()
    {
        health.OnDeath -= OnDeath;
    }
    
    private void OnDeath()
    {
        health.Die();
        OrderCanvas.animalDie(entity.animal);//Quitamos al muerto de los turnos
        TurnManager.OrderList();//Ordenamos la lista
        effect = Instantiate(deathEffect, transform.position, transform.rotation);
        effect.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
