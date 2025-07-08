using System;
using System.Collections.Generic;

namespace Hapheslime.Core.FSM;

public class StateMachine
{
    private StateNode _current;
    private Dictionary<Type, StateNode> _nodes = [];
    private HashSet<ITransition> _anyTransitions = [];

    public void Update(double delta)
    {
        var transition = GetTransition();
        if (transition != null)
            ChangeState(transition.To);

        _current.State?.Update(delta);
    }

    public void PhysicUpdate(double delta)
    {
        _current.State?.PhysicUpdate(delta);
    }

    public void SetState(IState state)
    {
        _current = _nodes[state.GetType()];
        _current.State?.Enter();
    }

    public void AddTransition(IState from, IState to, IPredicate condition)
    {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
    }

    public void AddAnyTransition(IState to, IPredicate condition)
    {
        _anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
    }

    private StateNode GetOrAddNode(IState state)
    {
        var node = _nodes.GetValueOrDefault(state.GetType());
        if (node == null)
        {
            node = new StateNode(state);
            _nodes.Add(state.GetType(), node);
        }

        return node;
    }

    private void ChangeState(IState state)
    {
        if (state == _current.State)
            return;

        var previousState = _current.State;
        var nextState = _nodes[state.GetType()].State;

        previousState?.Exit();
        nextState?.Enter();

        _current = _nodes[state.GetType()];
    }

    private ITransition GetTransition()
    {
        foreach (var transition in _anyTransitions)
            if (transition.Condition.Evaluate())
                return transition;

        foreach (var transition in _current.Transitions)
            if (transition.Condition.Evaluate())
                return transition;

        return null;
    }

    class StateNode(IState state)
    {
        public IState State { get; } = state;
        public HashSet<ITransition> Transitions { get; } = [];

        public void AddTransition(IState to, IPredicate condition) =>
            Transitions.Add(new Transition(to, condition));
    }
}
