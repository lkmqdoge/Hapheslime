using Godot;
using Hapheslime.Core.Actor;
using Hapheslime.Core.Actor.States;
using Hapheslime.Core.FSM;

namespace Hapheslime.Level.Entity;

[GlobalClass]
public partial class PlayerController : BaseController
{
    private bool _jumping = false;

    public override void _Ready()
    {
        base._Ready();

        var walkState = new WalkState(this);
        var idleState = new IdleState(this);
        var JumpState = new JumpState(this);
        var FallState = new FallState(this);

        StateMachine.AddTransition(
            walkState,
            JumpState,
            new FuncPredicate(() => _jumping)
        );
        StateMachine.AddTransition(JumpState, FallState, new FuncPredicate(() => true));
        StateMachine.AddTransition(
            walkState,
            FallState,
            new FuncPredicate(() => !Actor.IsOnFloor())
        );
        StateMachine.AddAnyTransition(walkState, new FuncPredicate(Actor.IsOnFloor));

        StateMachine.SetState(FallState);
    }
}
