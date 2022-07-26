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
        }

        private void InstallMediators()
        {
            Container.Bind<GameMenuMediator>().AsSingle().NonLazy();
        }
    }
}