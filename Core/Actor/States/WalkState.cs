using System;
using Godot;
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

    public override void Enter()
    {
        _actor.AnimationPlayer.Play(AnimationName);
    }

    public override void UpdatePhysic(double delta) { }
}
