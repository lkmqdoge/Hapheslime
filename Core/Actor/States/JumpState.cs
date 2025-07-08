using Godot;
using Hapheslime.Core.Actor.Commands;

namespace Hapheslime.Core.Actor.States;

[GlobalClass]
public partial class JumpState : ActorState
{
    public override void Enter()
    {
        _actor.AddCommand(new Jump(_controller.Mover));
        _stateMachine.SetState<FallState>();
    }
}