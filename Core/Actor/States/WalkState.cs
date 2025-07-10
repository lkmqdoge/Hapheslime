using System;
using Godot;
using Hapheslime.Common;
using Hapheslime.Core.Actor.Motion.Commands;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

[GlobalClass]
public partial class WalkState : ActorState
{
    private const string AnimationName = "walk";

    [Export]
    private float _speed = 10.0f;

    [Export]
    private float _acceleration = 4.0f;

    [Export]
    private float _friction = 3.0f;

    private Vector2 _direction;

    public WalkState()
    {
        AddAllowedKey("move_left");
        AddAllowedKey("move_right");
    }

    public override void UpdatePhysic(double delta)
    {
        _actor.AddCommand(
            new Move(_actor.Mover, new Vector2(_direction.X * _speed * (float)delta, 0))
        );
        _direction = Vector2.Zero;
    }

    public override void ProccesEvent(Event @event)
    {
        base.ProccesEvent(@event);
        if (@event is ControllerEvent v)
        {
            _direction = v.Controller.Direction;
            Logger.Debug(_direction.ToString());
        }
    }
}
