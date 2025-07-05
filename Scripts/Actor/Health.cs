using System;
using Godot;

namespace Hapheslime.Scripts.Actor;

[GlobalClass]
public partial class Health : Resource
{
    public event Action<int> DamageTaken;
    public event Action Died;

    public int Amount { get; protected set; }
    public int Max { get; protected set; }

    private bool _dead;

    public Health(int max)
    {
        Max = max;
    }

    public void Affect(int value)
    {
        Amount = Math.Clamp(Amount + value, 0, Max);
        DamageTaken?.Invoke(value);

        if (!_dead && Amount == 0)
        {
            _dead = true;
            Died?.Invoke();
        }
    }
}
