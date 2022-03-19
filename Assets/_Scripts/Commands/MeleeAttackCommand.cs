
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCommand : AttackCommand
{
    public MeleeAttackCommand(Entity target, Entity executor) : base(target, executor)
    {
        
    }
    public override void Execute()
    {
        base.Execute();
        EfectosHandler.generarEfecto( _target.transform.position, Efecto.MeleeAttack,_executor);
        EfectosHandler.generarEfecto(Efecto.getHurt, _target);
    }
}
