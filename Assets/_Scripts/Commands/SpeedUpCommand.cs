using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpCommand : Command
{
    public SpeedUpCommand(Entity target, Entity executor) : base(target, executor)
    {
        Execute();
    }
    public override void Execute()
    {
        _target.SpeedUp(_executor.speedToGive);
    }

    public override void Undo()
    {
        _target.SpeedUp(_executor.speedToGive * -1);
    }

}
