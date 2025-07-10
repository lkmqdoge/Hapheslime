using Godot;
using Hapheslime.Core.Actor;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public abstract partial class ActorTransition : Transition
{
    [Export]
    public bool Negated { get; set; }

    protected BaseActor _actor;

    public override void Setup(Node node) => _actor = (BaseActor)node;
}
