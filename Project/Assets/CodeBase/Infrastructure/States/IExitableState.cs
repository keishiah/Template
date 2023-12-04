namespace CodeBase.Infrastructure.States
{
    public interface IExitableState
    {
        void GetGameStateMachine(IGameStateMachine gameStateMachine);
        void Exit();
    }
}