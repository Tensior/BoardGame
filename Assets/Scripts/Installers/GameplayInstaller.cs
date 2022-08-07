using Core;
using Core.States;
using Core.Turns;
using Input;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallInput();
            InstallStates();
            InstallTurns();
            SetupExecutionOrder();
        }

        private void InstallInput()
        {
            Container.BindInterfacesTo<InputManager>().AsSingle().NonLazy();
        }

        private void InstallStates()
        {
            Container.BindInterfacesTo<GameStateManager>().AsSingle().NonLazy();
            Container.Bind<StartGameState>().AsSingle().NonLazy();
            Container.Bind<PassTurnState>().AsSingle().NonLazy();
            Container.Bind<StartTurnState>().AsSingle().NonLazy();
            Container.Bind<SmallUseDiceState>().AsSingle().NonLazy();
            Container.Bind<LargeUseDiceState>().AsSingle().NonLazy();
            Container.Bind<StatesContainer>().AsSingle().NonLazy();
        }

        private void InstallTurns()
        {
            Container.BindInterfacesTo<TurnsManager>().AsSingle().NonLazy();
        }

        private void SetupExecutionOrder()
        {
            Container.BindTickableExecutionOrder<GameStateManager>(0);
            Container.BindTickableExecutionOrder<InputManager>(10);
        }
    }
}