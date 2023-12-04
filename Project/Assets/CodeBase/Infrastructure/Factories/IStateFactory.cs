using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IStateFactory
    {
        T GetState<T>(IGameStateMachine gameStateMachine) where T : IExitableState;
        GameObject CreateGameBootstrapper();
    }
}