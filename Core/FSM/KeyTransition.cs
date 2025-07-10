using Godot;
using Godot.Collections;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public partial class KeyTransition : Node
{
    [Export]
    public Dictionary<string, State> KeyStates { get; private set; } = [];
}
