using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantAttackCommand : AttackCommand
{
    public DistantAttackCommand(Entity target, Entity executor) : base(target, executor)
    {      
        Execute();
    }
    public override void Execute()
    {
        base.Execute();
        EfectosHandler.generarEfecto(_executor.transform.position, _target.transform.position, Efecto.Rayo);
        EfectosHandler.generarEfecto(Efecto.getHurt, _target);
        EfectosHandler.generarEfecto(Efecto.Attack, _executor);
    }
    public override void Undo()
    {
        base.Undo();

    }
}
