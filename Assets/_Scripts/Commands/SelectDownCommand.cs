using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDownCommand : Command
{
    public SelectDownCommand(Entity target, Entity executor) : base(target, executor) { 
        
    }
    public override void Execute()
    {
        EntityManager.ChangeTarget(-1);
        Entity target = EntityManager.TargetEntity;
        
    }

    public override void Undo()
    {
        EntityManager.ChangeTarget(1);
        Entity target = EntityManager.TargetEntity;
    }
}
