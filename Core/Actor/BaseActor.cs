using System.Collections.Generic;
using Godot;
using Hapheslime.Common;
using Hapheslime.Core.Actor.Motion;
using Hapheslime.Core.Actor.Motion.Commands;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor;

[GlobalClass]
public partial class BaseActor : CharacterBody2D
{
    [Export]
    public Health Health { get; private set; }

    [Export]
    public AnimationPlayer AnimationPlayer { get; private set; }

    [Export]
    public StateMachine StateMachine { get; private set; }

    public Mover Mover { get; private set; }

    private readonly Stack<BaseActorCommand> _doStack = [];

    public override void _Ready()
    {
        Mover = new(this);
    }

    public override void _PhysicsProcess(double delta)
    {
        while (_doStack.Count != 0)
            _doStack.Pop().Do();
    }

    public void AddCommand(BaseActorCommand command) => _doStack.Push(command);
}
