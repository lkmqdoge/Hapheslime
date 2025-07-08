using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

public partial class WalkState : BaseState
{
    public WalkState(BaseController controller)
        : base(controller) { }

    public override void Enter()
    {
        base.Enter();
        _animation.Play("walk");
    }

    public override void PhysicUpdate(double delta)
    {
        base.PhysicUpdate(delta);


    }
}
