using Godot;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public partial class InstantTransition : Transition
{
    public override bool CheckCondition() => true;
}
