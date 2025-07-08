using Godot;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

[GlobalClass]
public partial class ActorStateMachine : StateMachine
{
    [Export]
    public Controller Controller { get; private set; }

    public override void _Ready() { }
}
