using System.Collections.Generic;
using Godot;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public abstract partial class State : Node
{
    protected StateMachine _stateMachine;

    private readonly HashSet<Transition> _transitions;

    public virtual void Setup(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public virtual void UpdateLogic(double delta)
    {
        CheckTransitions();
    }

    public virtual void UpdatePhysic(double delta) { }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public void AddTransition(Transition transition)
    {
        _transitions.Add(transition);
    }

    public void RemoveTransition(Transition transition)
    {
        _transitions.Remove(transition);
    }

    private void CheckTransitions()
    {
        foreach (var transition in _transitions)
            if (transition.CheckCondition())
                _stateMachine.SetState(transition.To);
    }
}
