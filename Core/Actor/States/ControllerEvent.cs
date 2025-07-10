using Hapheslime.Core.FSM;

namespace Hapheslime.Core.Actor.States;

public class ControllerEvent(Controller controller, string key) : Event
{
    public Controller Controller { get; init; } = controller;
    public string Key { get; init; } = key;
}
