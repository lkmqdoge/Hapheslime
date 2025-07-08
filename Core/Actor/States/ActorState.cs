using System;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

public abstract partial class ActorState : State
{
    protected Controller _controller;
    protected Actor _actor;

    public override void Setup(StateMachine stateMachine)
    {
        base.Setup(stateMachine);

        if (stateMachine is ActorStateMachine v)
        {
            _controller = v.Controller;
            _actor = v.Controller.Actor;
        }
        else
        {
            throw new NotSupportedException(
                $"{stateMachine.GetType()} is not supported to use with {GetType()}"
            );
        }
    }
}
