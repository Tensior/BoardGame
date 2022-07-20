using UIMediation.Mediators;
using UIView.ViewModels;
using Zenject;

namespace Installers
{
    public class MainMenuUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallViews();
            InstallMediators();
        }

        private void InstallViews()
        {
            Container.Bind<MainMenuVM>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void InstallMediators()
        {
            Container.Bind<MainMenuMediator>().AsSingle().NonLazy();
        }
    }
}