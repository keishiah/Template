using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;

namespace CodeBase.Infrastructure.States
{
    public class LoadPlayerProgressState : IState
    {
        private IGameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IEnumerable<IProgressReader> _progressReaderServices;
        private readonly IPlayerProgressService _progressService;


        public LoadPlayerProgressState(IPlayerProgressService progressService,
            ISaveLoadService saveLoadService, IEnumerable<IProgressReader> progressReaderServices)
        {
            _saveLoadService = saveLoadService;
            _progressService = progressService;
            _progressReaderServices = progressReaderServices;
        }

        public void SetGameStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            var progress = LoadProgressOrInitNew();

            NotifyProgressReaderServices(progress);

            _gameStateMachine.Enter<LoadLevelState, string>(InfrastructureAssetPath.StartGameScene);
        }

        private void NotifyProgressReaderServices(PlayerProgress progress)
        {
            foreach (var reader in _progressReaderServices)
                reader.LoadProgress(progress);
        }

        public void Exit()
        {
        }

        private PlayerProgress LoadProgressOrInitNew()
        {
            _progressService.Progress =
                _saveLoadService.LoadProgress()
                ?? NewProgress();
            return _progressService.Progress;
        }

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();

            // init start state of progress here

            return progress;
        }
    }
}