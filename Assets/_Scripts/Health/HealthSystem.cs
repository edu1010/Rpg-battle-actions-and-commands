using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    [SerializeField]
    public float maxHealth = 10;

    public float MaxHealth => maxHealth;
    
    public float CurrentHealth { get; set; }
    public float CurrentHealthCopia;

    public bool Dead {  get; private set; }

    public delegate void OnDeathDelegate();
    public  OnDeathDelegate OnDeath;

    public delegate void OnHitDelegate(float fraction);
    public static OnHitDelegate OnHit;
    float contador = 0.0f;

    protected virtual void Start()
    {
        CurrentHealth = maxHealth;
        Dead = false;
    }
    
    public virtual void TakeDamage(int amount)
    {       
           CurrentHealth -= amount;

            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            if (CurrentHealth <= 0.0f && !Dead)
            {               
                OnDeath?.Invoke();
                Dead = true;
            }
        
        
    }

    public void Die()
    {
        Dead = true;
    }
   
    public bool isAlive()
    {
        if (Dead)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void IRevived()
    {
        Dead = false;
    }
    private void Update()
    {
        contador += Time.deltaTime;
        CurrentHealthCopia = CurrentHealth;
    }
}
