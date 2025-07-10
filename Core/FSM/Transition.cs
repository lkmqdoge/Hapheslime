using Godot;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public abstract partial class Transition : Node
{
    [Export]
    public State To { get; private set; }

    public virtual void Setup(Node node) { }

    public abstract bool CheckCondition();
}
