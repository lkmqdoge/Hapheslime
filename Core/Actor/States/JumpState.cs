using Godot;
using Hapheslime.Core.Actor.Motion.Commands;

namespace Hapheslime.Core.Actor.States;

[GlobalClass]
public partial class JumpState : ActorState
{
    [Export]
    private float _height = -40.0f;

    public override void Enter()
    {
        _actor.AddCommand(new Jump(_actor.Mover));
        _stateMachine.SetState<FallState>();
    }
}