using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCommand : Command
{
    public HealthCommand(Entity target, Entity executor) : base(target, executor)
    {
        Execute();
    }

    public override void Execute()
    {
        _target.Heal(_executor.HealthkPoints);
    }

    public override void Undo()
    {
        _target.TakeDamage(_executor.HealthkPoints);
    }
}
