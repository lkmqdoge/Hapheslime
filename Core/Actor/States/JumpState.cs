using Hapheslime.Core.Actor.Commands;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

public class JumpState : BaseState
{
    public JumpState(BaseController controller)
        : base(controller) { }

    public override void Enter()
    {
        base.Enter();
        _actor.AddCommand(new Jump(_controller.Mover));
    }
}
