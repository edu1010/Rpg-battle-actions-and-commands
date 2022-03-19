using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    protected Entity _target;//SI HAY VARIOS TARGET VOLVEMOS ESTO UNA LISTA Y EN entitiManager TAMBIEN
    protected Entity _executor;
    protected Command(Entity target, Entity executor)
    {
        _target = target;
        _executor = executor;
    } 
    protected Command( Entity executor)
    {
        _executor = executor;
    }

    public abstract void Execute();

    public abstract void Undo();
}
