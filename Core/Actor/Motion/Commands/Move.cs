using Godot;

namespace Hapheslime.Core.Actor.Motion.Commands;

public class Move(Mover mover, Vector2 amount) : BaseActorCommand(mover)
{
    private Vector2 _amount = amount;

    public override void Do()
    {
        _mover.Velocity += _amount;
        _mover.Move();
    }

    public override void Undo()
    {
        _mover.Velocity -= _amount;
        _mover.Move();
    }
}
