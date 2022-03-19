using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    public AttackCommand(Entity target, Entity executor) : base(target,executor)
    {
       
    }

    public override void Execute()
    {
        _target.TakeDamage(_executor.AttackPoints);     
    }

    public override void Undo()
    {
        if (_target.IamAlive())//Si esta vivo curamos
        {
            _target.Heal(_executor.AttackPoints);
        }
        else
        {
            
            _target.transform.gameObject.SetActive(true);
            _target.ReturnToLife();
            _target.Heal(_executor.AttackPoints);
            TurnManager.OrderList();


        }
        
    }
}
