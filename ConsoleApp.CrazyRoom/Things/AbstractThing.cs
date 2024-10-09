﻿namespace ConsoleApp.CrazyRoom.Things;

// public delegate void InteractionEventHandler(T something);
// public event InteractionEventHandler? OnInteract;

using ConsoleApp.CrazyRoom.Position;
using ConsoleApp.CrazyRoom.Hero;

public abstract class Thing(char symbol, IPosition position, sbyte rangeOfAction) : IGameCharacter
{
    private readonly char _symbol = symbol;
    private readonly sbyte _rangeOfAction = rangeOfAction;
    private IPosition _position = position;
    
    public void SetPosition(IPosition position)
    {
        _position = position;
    }
    
    public IPosition GetPosition()
    {
        return _position;
    }
    
    /// <summary>
    /// Возвращает символ, которым будет обозначен предмет в игровой комнате
    /// </summary>
    public char GetAvatar()
    {
        return _symbol;
    }

    /// <summary>
    /// Находится ли текущая позиция в зоне активности предмета?
    /// </summary>
    public bool InTheAreaOfAction(IPosition position)
    {
        return Math.Abs(position.X - _position.X) <= _rangeOfAction && Math.Abs(position.Y - _position.Y) <= _rangeOfAction;
    }
    
    /// <summary>
    /// Взаимодействие с окружающим миром
    /// </summary>
    public abstract void InteractWith(IGameCharacter? actor);
    
    public abstract void TakeDamage(int value);
}