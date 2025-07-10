using Godot;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public partial class ActorIsMoving : ActorTransition
{
    public override bool CheckCondition() => _actor.Velocity == Vector2.Zero && !Negated;
}
