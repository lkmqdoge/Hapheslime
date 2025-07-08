using System;
using Godot;

namespace Hapheslime.Core.Actor;

[GlobalClass]
public partial class InputReader : Node
{
    const string MovePositive = "move_right";
    const string MoveNegative = "move_left";
    const string Jump = "jump";

    public event Action<float> Move;
    public event Action JumpStart;
    public event Action JumpEnd;

    public bool Enabled
    {
        get => _enabled;
        set
        {
            _enabled = value;
            SetProcessUnhandledInput(value);
            SetPhysicsProcess(value);
        }
    }

    private bool _enabled = true;

    public override void _PhysicsProcess(double delta)
    {
        var move = Input.GetAxis(MoveNegative, MovePositive);
        Move.Invoke(move);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed(Jump))
            JumpStart.Invoke();

        if (@event.IsActionReleased(Jump))
            JumpEnd.Invoke();
    }
}
