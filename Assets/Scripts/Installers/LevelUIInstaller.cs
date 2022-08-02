using UIMediation.Mediators;
using UIView.ViewModels;
using Zenject;

namespace Installers
{
    public class LevelUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallViews();
            InstallMediators();
        }

        private void InstallViews()
        {
            Container.Bind<GameMenuVM>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<GameTurnVM>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<UseDiceVM>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void InstallMediators()
        {
            Container.Bind<GameMenuMediator>().AsSingle().NonLazy();
            Container.Bind<GameTurnMediator>().AsSingle().NonLazy();
            Container.Bind<UseDiceMediator>().AsSingle().NonLazy();
        }
    }
}