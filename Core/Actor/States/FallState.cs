using Godot;
using Hapheslime.Core.Actor.Motion.Commands;

namespace Hapheslime.Core.Actor.States;

[GlobalClass]
public partial class FallState : ActorState
{
    [Export]
    private float _gravity = 90.0f;

    [Export]
    private float _speed = 78.0f;

    public override void UpdatePhysic(double delta)
    {
        _actor.AddCommand(new Move(_actor.Mover, new Vector2(0, _gravity * (float)delta)));
    }
}
