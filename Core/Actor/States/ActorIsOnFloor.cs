using Godot;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public partial class ActorIsOnFloor : ActorTransition
{
    public override bool CheckCondition() => _actor.IsOnFloor() && !Negated;
}
