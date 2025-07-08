using Godot;

namespace Hapheslime.Core.Actor;

[GlobalClass]
public abstract partial class Controller : Node
{
    [Export]
    public Actor Actor { get; set; }

    public Mover Mover { get; protected set; }

    public bool Enabled { get; set; } = true;

    public Vector2 Direction { get; private set; }

    public override void _PhysicsProcess(double delta)
    {
        Direction = Input.GetVector();
    }
}
