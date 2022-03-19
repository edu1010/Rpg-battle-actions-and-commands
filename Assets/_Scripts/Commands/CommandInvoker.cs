using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
     static Queue<Command> CommandQueque;
     static List<Command> CommandHistory;
     static int index = 0;

    // Start is called before the first frame update
    void Awake()
    {
        CommandQueque = new Queue<Command>();
        CommandHistory = new List<Command>();
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteAll();
    }
    public static void AddCommand(Command command)
    {
        if(CommandQueque == null)
        {
            CommandQueque = new Queue<Command>();
        }
        CommandQueque.Enqueue(command);
        if(CommandHistory == null)
        {
            CommandHistory = new List<Command>();
        }
        
        while(CommandHistory.Count > index)//Si añadimos un nuevo comomando despues de hacer un undo esto borrara los comandos que tengamos por delante(que teniamos guardado para hacer el redo)
        {
            CommandHistory.RemoveAt(index);
        }
    }
    public static void ExecuteAll()
    {
        if (CommandQueque.Count > 0)
        {
            Command command = CommandQueque.Dequeue();
            command.Execute();
            CommandHistory.Add(command);
            index++;
        }
    }
    public static void Undo()
    {
        if (index > 0)
        {
            index--;
            CommandHistory[index].Undo();
        }
    }
    public static void Redo()
    {
        if (index < CommandHistory.Count )
        {
            index++;
            CommandHistory[index-1].Execute();
            
        }
        
    }


}
