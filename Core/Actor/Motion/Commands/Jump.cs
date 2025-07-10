using Godot;

namespace Hapheslime.Core.Actor.Motion.Commands;

public class Jump(Mover mover) : BaseActorCommand(mover)
{
    public readonly float _height = -40f;

    public Jump(Mover mover, float height)
        : this(mover)
    {
        _height = height;
    }

    public override void Do()
    {
        _mover.Velocity += new Vector2(0, _height);
        _mover.Move();
    }

    public override void Undo()
    {
        _mover.Velocity -= new Vector2(0, _height);
        _mover.Move();
    }
}
