using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private void OnAttack(InputValue value)
    {
        MakeAttack();
    }
    private void OnUndo(InputValue value)
    {
        Undo();
    }
    private void OnRedo(InputValue value)
    {
        Redo();
    }
    private void OnHeal(InputValue value)
    {
        MakeHeal();
    }
    private void OnDistantAttack(InputValue value)
    {
        MakeDistantAttack();
    }

    private void OnSpeedUp(InputValue value)
    {
        MakeSpeedUp();
    }    

    private void OnEndTurn(InputValue value)
    {
        EndTurn();
    }
    private void OnSelectUpTarget(InputValue value)
    {
        SelectUpTarget();
    }
    private void OnSelectDownTarget(InputValue value)
    {
        SelectDownTarget();
    }

    public void SelectUpTarget()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new SelectUpCommand(target, executor);
        CommandInvoker.AddCommand(command);
    }
    public void SelectDownTarget()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new SelectDownCommand(target, executor);
        CommandInvoker.AddCommand(command);
    }
    public void EndTurn()
    {
        Entity executor = EntityManager.ExecutorEntity;
        var command = new EndTurnCommand(executor);
        CommandInvoker.AddCommand(command);
    }
    public void MakeHeal()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new HealthCommand(target, executor);
        CommandInvoker.AddCommand(command);
        EndTurn();
    }
    public void MakeDistantAttack()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new DistantAttackCommand(target, executor);
        CommandInvoker.AddCommand(command);
        EndTurn();
    }
    public void MakeAttack()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new MeleeAttackCommand(target, executor);
        CommandInvoker.AddCommand(command);
        EndTurn();
    }

    public void MakeSpeedUp()
    {
        Entity executor = EntityManager.ExecutorEntity;
        Entity target = EntityManager.TargetEntity;
        var command = new SpeedUpCommand(target, executor);
        CommandInvoker.AddCommand(command);
        EndTurn();
    }

    public void Undo()
    {
        CommandInvoker.Undo();
    }
    public void Redo()
    {
        CommandInvoker.Redo();
    }
}
