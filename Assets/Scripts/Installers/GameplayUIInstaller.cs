using UIMediation.Mediators;
using UIView.ViewModels;
using Zenject;

namespace Installers
{
    public class GameplayUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallViews();
            InstallMediators();
        }

        private void InstallViews()
        {
            Container.Bind<GameHUDVM>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<GameTurnVM>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<UseDiceVM>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<PlayerMoveDirectionsVM>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void InstallMediators()
        {
            Container.Bind<GameHUDMediator>().AsSingle().NonLazy();
            Container.Bind<GameTurnMediator>().AsSingle().NonLazy();
            Container.Bind<UseDiceMediator>().AsSingle().NonLazy();
            Container.Bind<PlayerMoveDirectionsMediator>().AsSingle().NonLazy();
        }
    }
}