using Hapheslime.Common;

namespace Hapheslime.Core.Actor.Motion.Commands;

public abstract class BaseActorCommand(Mover mover) : ICommand
{
    protected Mover _mover = mover;

    public abstract void Do();
    public abstract void Undo();
}
