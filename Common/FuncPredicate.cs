using System;

namespace Hapheslime.Common;

public class FuncPredicate(Func<bool> func) : IPredicate
{
    public bool Evaluate()
    {
        return func.Invoke();
    }
}
