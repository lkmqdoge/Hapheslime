namespace Hapheslime.Core.FSM;

public interface ITransition
{
    IState To { get; }
    IPredicate Condition { get; }
}
