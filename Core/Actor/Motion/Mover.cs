using Godot;

namespace Hapheslime.Core.Actor.Motion;

public class Mover(BaseActor actor)
{
    public Vector2 Velocity { get; set; }

    private readonly BaseActor _actor = actor;

    public void Move()
    {
        _actor.Velocity = Velocity;
        _actor.MoveAndSlide();
    }
}