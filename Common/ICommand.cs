namespace Hapheslime.Common;

public interface ICommand
{
    void Do();
    void Undo();
}