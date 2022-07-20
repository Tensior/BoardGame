using UIMediation.Mediators;
using UIView.ViewModels;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallViews();
            InstallMediators();
        }

        private void InstallViews()
        {
            Container.Bind<LivesVM>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ScoreVM>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<PauseMenuVM>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void InstallMediators()
        {
            Container.Bind<PauseMenuMediator>().AsSingle().NonLazy();
        }
    }
}