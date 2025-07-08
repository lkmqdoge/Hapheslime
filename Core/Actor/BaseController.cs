using System;
using Godot;
using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor;

[GlobalClass]
public abstract partial class BaseController : Node
{
    [Export]
    public BaseActor Actor { get; set; }

    public bool Enabled { get; set; } = true;

    public StateMachine StateMachine { get; protected set; }

    public Mover Mover { get; protected set; }

    public InputReader InputReader { get; protected set; }
}
