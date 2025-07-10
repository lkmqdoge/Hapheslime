using Godot;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor;

[GlobalClass]
public abstract partial class Controller : Node
{
    [Export]
    public BaseActor Actor { get; set; }

    public bool Enabled { get; set; } = true;

    public Vector2 Direction { get; protected set; }

    protected StateMachine _stateMachine;

    public override void _Ready()
    {
        _stateMachine = Actor.StateMachine;
    }
}
