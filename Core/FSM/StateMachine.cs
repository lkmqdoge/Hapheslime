using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public abstract partial class StateMachine : Node
{
    public event Action<State> StateChanged;

    [Export]
    protected State _currentState;

    public override void _Ready()
    {
        foreach (var child in GetChildren())
            if (child is State v)
                v.Setup(this);
    }

    public override void _PhysicsProcess(double delta) => _currentState.UpdatePhysic(delta);

    public override void _Process(double delta) => _currentState.UpdateLogic(delta);

    public void SetState(State state)
    {
        if (state != null)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();

            StateChanged?.Invoke(state);
        }
    }

    public void SetState<T>()
        where T : State
    {
        foreach (var child in GetChildren())
            if (child is State v && child.Name == nameof(T))
                SetState(v);
    }

    public void ProccesEvent(Event @event) => _currentState.ProccesEvent(@event);

    public IEnumerable<string> GetStateKeys() => _currentState.GetKeyConditions().Concat(_currentState.GetAllowedKeys());
}
