using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    Entity entity;
   
    private void Start()
    {
        entity = GetComponent<Entity>();
    }
    float timer = 0;
    
    // Update is called once per frame
    void Update()
    {
        //Random.seed = (int)Time.time;
       
        if (entity == EntityManager.ExecutorEntity)
        {
            ControlCanvasButtons.DesactivateCanvas();
            timer += Time.deltaTime;
            Command commandAccion;
            if (timer > 2f)
            {
                timer = 0;
                int random = Random.Range(1, 5);
                switch (random)
                {
                    case (1):
                        commandAccion = MakeAttack();
                        if (selectTargetIA(commandAccion))
                        {

                        }
                        else
                        {
                            selectTargetIA(commandAccion);
                        }
                        break;
                    case (2):
                        commandAccion = MakeDistantAttack();
                        if (selectTargetIA(commandAccion))
                        {

                        }
                        else
                        {
                            selectTargetIA(commandAccion);
                        }
                        break;
                    case (3):
                        commandAccion = MakeHeal();
                        if (selectTargetIA(commandAccion))
                        {

                        }
                        else
                        {
                            selectTargetIA(commandAccion);
                        }
                        break;
                    default:
                        commandAccion = MakeSpeedUp();
                        if (selectTargetIA(commandAccion))
                        {

                        }
                        else
                        {
                            selectTargetIA(commandAccion);
                        }
                        break;
                }
                
                CommandInvoker.AddCommand(commandAccion);
                EndTurn();
            }
        }
        
    }
    bool selectTargetIA(Command command)
    {
        bool finish = false;
        bool targetIsEnemy = false;
        bool targetIsAllie = false;
        if(finish == true)//Control recursividad
        {
            return finish;
        }
        int veces = Random.Range(1, 5);
        if (command is HealthCommand || command is SpeedUpCommand)
        {
            for (int i = 1; i < veces; i++)
            {
                if (Random.Range(1, 3) == 1)
                {
                    SelectUpTarget();
                }
                else
                {
                    SelectDownTarget();
                }
            }
            Entity[] AlliesVivos = EntityManager.GetAlliesAlive(EntityManager.ExecutorEntity);
            foreach (Entity entity in AlliesVivos)
            {
                if (entity == EntityManager.TargetEntity)
                {
                    targetIsAllie = true;
                    finish = true;
                }
            }
            if (targetIsAllie == false)
            {
                finish = false;
            }
        }
        else
        {
            for (int i = 1; i < veces; i++)
            {
                if (Random.Range(1, 3) == 1)
                {
                    SelectUpTarget();
                }
                else
                {
                    SelectDownTarget();
                }
            }
            Entity[] enemigosVivos = EntityManager.GetEnemiesAlive(EntityManager.ExecutorEntity);
            foreach (Entity entity in enemigosVivos)
            {
                if (entity == EntityManager.TargetEntity)
                {
                    targetIsEnemy = true;
                    finish = true;
                }
            }
            if (targetIsEnemy == false)
            {
                finish = false;
            }
        }
        if(finish == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void SelectUpTarget()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new SelectUpCommand(target, executor);
        CommandInvoker.AddCommand(command);
    }
    private void SelectDownTarget()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new SelectDownCommand(target, executor);
        CommandInvoker.AddCommand(command);
    }
    private void EndTurn()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var commandEnd = new EndTurnCommand(executor);//Se añade este segundo comando dado que una vez dada esta acción no se pueden realizar más ese turno y por tanto se realiza el comando de acabar turno
        CommandInvoker.AddCommand(commandEnd);

    }
    private Command MakeHeal()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new HealthCommand(target, executor);
        return command;
    }
    private Command MakeDistantAttack()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new DistantAttackCommand(target, executor);
        return command;
    }
    private Command MakeAttack()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new MeleeAttackCommand(target, executor);
        return command;
    }

    private Command MakeSpeedUp()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new SpeedUpCommand(target, executor);
        return command;
    }
}
