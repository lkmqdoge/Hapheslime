using Godot;

namespace Hapheslime.Core.Actor.Commands;

public class Jump : BaseActorCommand
{
    private float _height = -40f;

    public Jump(Mover mover)
        : base(mover) { }

    public override void Do()
    {
        _mover.Velocity += new Vector2(0, _height);
    }

    public override void Undo()
    {
        _mover.Velocity -= new Vector2(0, _height);
    }
}
