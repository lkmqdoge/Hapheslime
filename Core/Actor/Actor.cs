using System.Collections.Generic;
using Godot;
using Hapheslime.Core.Actor.Commands;

namespace Hapheslime.Core.Actor;

[GlobalClass]
public abstract partial class Actor : CharacterBody2D
{
    public Health Health { get; }
    public AnimationPlayer AnimationPlayer { get; }

    private Stack<BaseActorCommand> _doStack = [];
    private Stack<BaseActorCommand> _undoStack = [];

    public override void _PhysicsProcess(double delta)
    {
        if (_doStack.Count != 0)
        {
            var command = _doStack.Pop();
            command.Do();
            _undoStack.Push(command);
        }
    }

    public void AddCommand(BaseActorCommand command)
    {
        _doStack.Push(command);
    }
}
