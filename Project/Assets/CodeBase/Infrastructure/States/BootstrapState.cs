using CodeBase.Services.StaticDataService;


namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void GetGameStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            InitServices();
            _gameStateMachine.Enter<LoadPlayerProgressState>();
        }

        private void InitServices()
        {
            _staticDataService.Initialize();
        }

        public void Exit()
        {
        }
    }
}