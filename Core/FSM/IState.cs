namespace Hapheslime.Core.FSM;

public interface IState
{
    void Enter();
    void Update(double delta);
    void PhysicUpdate(double delta);
    void Exit();
}