using Godot;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

[GlobalClass]
public partial class ActorStateMachine : StateMachine
{
    [Export]
    public BaseActor Actor { get; private set; }
}
