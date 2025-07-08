using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

public partial class IdleState : BaseState
{
    public IdleState(BaseController controller)
        : base(controller) { }

    public override void Enter()
    {
        base.Enter();
        _animation.Play("walk");
    }
}
