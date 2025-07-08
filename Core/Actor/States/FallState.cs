using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

public partial class FallState : BaseState
{
    public FallState(BaseController controller)
        : base(controller) { }

    public override void Enter()
    {
        base.Enter();
        _animation.Play("fall");
    }
}
