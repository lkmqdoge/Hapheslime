using Godot;
using Hapheslime.Common;
using Hapheslime.Core.Actor;
using Hapheslime.Core.Actor.States;

namespace Hapheslime.Level.Entity;

[GlobalClass]
public partial class PlayerController : Controller
{
    public override void _Ready()
    {
        base._Ready();

        _stateMachine.StateChanged += (state) => Logger.Debug($"Player state changed to {state}");
    }

    public override void _PhysicsProcess(double delta)
    {
        Direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        foreach (var action in _stateMachine.GetStateKeys())
            if (@event.IsAction(action))
                _stateMachine.ProccesEvent(new ControllerEvent(this, action));
    }
}
