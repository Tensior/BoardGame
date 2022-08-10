using Core;
using Core.Players;
using Core.States;
using Core.Turns;
using Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Player[] _players;

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
            Container.Bind<MovePlayerState>().AsSingle().NonLazy();
            Container.Bind<SelectDirectionState>().AsSingle().NonLazy();
            Container.Bind<CheckFinishState>().AsSingle().NonLazy();
            Container.Bind<GameFinishState>().AsSingle().NonLazy();
            Container.Bind<StatesContainer>().AsSingle().NonLazy();
            
            Container.Bind<PlayerMovesHolder>().AsSingle().NonLazy();
        }

        private void InstallTurns()
        {
            Container.BindInterfacesTo<TurnsManager>().AsSingle().NonLazy();
            Container.Bind<IPlayerProvider>().To<PlayerProvider>().AsSingle().NonLazy();
            Container.Bind<IPlayer[]>().FromInstance(_players).WhenInjectedInto<PlayerProvider>().NonLazy();
        }

        private void SetupExecutionOrder()
        {
            Container.BindTickableExecutionOrder<GameStateManager>(0);
            Container.BindTickableExecutionOrder<InputManager>(10);
        }
    }
}