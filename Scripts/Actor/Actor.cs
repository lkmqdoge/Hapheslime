using Godot;

namespace Hapheslime.Scripts.Actor;

[GlobalClass]
public partial class Actor : CharacterBody2D
{
    [Export]
    public Health Health { get; private set; }

    public Mover Mover { get; private set; }

    public Controller Controller { get; private set; }
}
