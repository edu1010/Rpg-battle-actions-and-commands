using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float Damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageTaker health = collision.GetComponent<IDamageTaker>();
        if (health != null)
        {
            //health.TakeDamage(Damage);
        }else
        {
            //Destroy(gameObject);
        }


    }
}
