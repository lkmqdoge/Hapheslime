using Godot;

namespace Hapheslime.Core.Actor.Commands;

public class Move : BaseActorCommand
{
    private Vector2 _amount;

    public Move(Mover mover, Vector2 amount)
        : base(mover)
    {
        _amount = amount;
    }

    public override void Do()
    {
        _mover.Velocity += _amount;
    }

    public override void Undo()
    {
        _mover.Velocity -= _amount;
    }
}
