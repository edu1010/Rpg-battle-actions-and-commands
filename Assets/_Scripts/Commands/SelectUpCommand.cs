using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUpCommand : Command
{
   public SelectUpCommand(Entity target, Entity executor) : base(target, executor)
    {
        
    }

    public override void Execute()
    {
        EntityManager.ChangeTarget(1);
        //Entity target = EntityManager.TargetEntity;
    }

    public override void Undo()
    {
        EntityManager.ChangeTarget(-1);
        //Entity target = EntityManager.TargetEntity;
    }
}
