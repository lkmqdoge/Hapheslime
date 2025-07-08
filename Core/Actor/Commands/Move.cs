using Godot;

namespace Hapheslime.Core.Actor.Commands;

public class Move : BaseActorCommand
{
    private float _amount;

    public Move(Mover mover, float amount)
        : base(mover)
    {
        _amount = amount;
    }

    public override void Do()
    {
        _mover.Velocity += new Vector2(_amount, 0);
    }

    public override void Undo()
    {
        _mover.Velocity -= new Vector2(_amount, 0);
    }
}
