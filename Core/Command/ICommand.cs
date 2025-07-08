namespace Hapheslime.Core.Command;

public interface ICommand
{
    void Do();
    void Undo();
}