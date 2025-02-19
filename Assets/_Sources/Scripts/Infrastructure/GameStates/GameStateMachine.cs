﻿using System;
using System.Collections.Generic;
using _Sources.Scripts.Infrastructure.Factory;
using _Sources.Scripts.Infrastructure.Services;
using _Sources.Scripts.Infrastructure.Services.PersistentProgress;
using _Sources.Scripts.Infrastructure.Services.SaveLoad;
using _Sources.Scripts.UI;

namespace _Sources.Scripts.Infrastructure.GameStates
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        public GameStateMachine(SceneLoader sceneLoader, LoadingScreen loadingScreen, AllServices allServices)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, allServices),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingScreen, allServices.Single<IGameFactory>(), allServices.Single<IPersistentProgressService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, allServices.Single<IPersistentProgressService>(), allServices.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
            
        }

        //payload smth like useful overload for method, additional parameter
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
            
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            
            TState state = GetState<TState>();
            _activeState = state;
            
            return state;
        }

        //downcast
        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}