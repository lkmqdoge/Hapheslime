using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Hapheslime.Core.FSM;

[GlobalClass]
public abstract partial class State : Node
{
    protected StateMachine _stateMachine;

    private readonly HashSet<Transition> _transitions = [];
    private Godot.Collections.Dictionary<string, State> _keyStates;
    private readonly HashSet<string> _allowedKeys = [];

    public virtual void Setup(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;

        foreach (var child in GetChildren())
        {
            if (child is Transition v)
            {
                _transitions.Add(v);
                ProccesTransition(v);
            }
            else if (child is KeyTransition u)
                _keyStates = u.KeyStates;
        }
    }

    public virtual void UpdateLogic(double delta)
    {
        CheckTransitions();
    }

    public virtual void UpdatePhysic(double delta) { }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void ProccesEvent(Event @event) { }

    public void AddTransition(Transition transition) => _transitions.Add(transition);

    public void RemoveTransition(Transition transition) => _transitions.Remove(transition);

    public ICollection<string> GetKeyConditions() => _keyStates?.Keys ?? [];

    public void AddAllowedKey(string key) => _allowedKeys.Add(key);

    public void RemoveAllowedKey(string key) => _allowedKeys.Add(key);

    public ICollection<string> GetAllowedKeys() => _allowedKeys;

    public override string ToString() => Name;

    protected State GetKeyState(string key) => _keyStates[key];

    protected bool TryGetState(string key, out State state) =>
        _keyStates.TryGetValue(key, out state);

    protected virtual void ProccesTransition(Transition transition) { }

    private void CheckTransitions()
    {
        foreach (var transition in _transitions)
            if (transition.CheckCondition())
                _stateMachine.SetState(transition.To);
    }
}
