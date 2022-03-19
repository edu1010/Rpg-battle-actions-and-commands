using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    Transform transform { get; }
 
    //poner lista con todos los comandos
    void TakeDamage(int amount);
    void Heal(int amount);
    bool IamAlive();
    
}
