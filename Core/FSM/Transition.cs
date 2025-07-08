using Hapheslime.Common;

namespace Hapheslime.Core.FSM;

public class Transition(State to, IPredicate condition)
{
    public readonly State To = to;
    public readonly IPredicate Condition = condition;

    public bool CheckCondition() => Condition.Evaluate();
}
