using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCommand : Command
{
    public EndTurnCommand(Entity executor) : base(executor)
    {
        Execute();
    }
    public override void Execute()
    {
        _executor.turnFinish = true;
        TurnManager.nextTurn();
        EfectosHandler.generarEfecto(Efecto.Shadow);
        ControlCanvasButtons.ActivateCanvas();
        
    }   

    public override void Undo()
    {
        _executor.turnFinish = false;
        TurnManager.nextTurn();
        EfectosHandler.generarEfecto(Efecto.Shadow);

    }
}
