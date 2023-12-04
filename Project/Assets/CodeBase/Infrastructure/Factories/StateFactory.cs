﻿using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class StateFactory : IStateFactory
    {
        private DiContainer _container;

        public StateFactory(DiContainer container)
        {
            _container = container;
        }

        public T GetState<T>(IGameStateMachine gameStateMachine) where T : IExitableState
        {
            var state = _container.Resolve<T>();
            state.GetGameStateMachine(gameStateMachine);
            return state;
        }

        public GameObject CreateGameBootstrapper()
        {
            return _container.InstantiatePrefabResource(InfrastructureAssetPath.GameBootstraper);
        }
    }
}