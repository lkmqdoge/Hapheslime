using System;
using Godot;
using Hapheslime.Core.Actor;

namespace Hapheslime.Core.FSM;

public abstract class BaseState : IState
{
    protected readonly BaseController _controller;
    protected readonly AnimationPlayer _animation;
    protected readonly BaseActor _actor;

    public BaseState(BaseController controller)
    {
        _controller = controller;
        _actor = controller.Actor;
        _animation = controller.Actor.AnimationPlayer;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void PhysicUpdate(double delta) { }

    public virtual void Update(double delta) { }
}
