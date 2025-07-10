using System;
using Hapheslime.Common;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

public abstract partial class ActorState : State
{
    protected BaseActor _actor;

    public override void Setup(StateMachine stateMachine)
    {
        if (stateMachine is ActorStateMachine v)
        {
            _actor = v.Actor;
        }
        else
        {
            throw new NotSupportedException(
                $"{stateMachine.GetType()} is not supported to use with {GetType()}"
            );
        }

        base.Setup(stateMachine);
    }

    public override void ProccesEvent(Event @event)
    {
        if (@event is ControllerEvent v)
        {
            if (TryGetState(v.Key, out State state))
                _stateMachine.SetState(state);
        }
    }

    protected override void ProccesTransition(Transition transition)
    {
        transition.Setup(_actor);
    }
}
