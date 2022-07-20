using Input.Interfaces;
using Input.Providers;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallInput();
            InstallPools();
        }

        private void InstallInput()
        {
            Container.Bind<InputActions>().FromNew().AsSingle().NonLazy();
            Container.Bind<IInputProvider>().To<InputProvider>().AsSingle().NonLazy();
        }

        private void InstallPools()
        {
            
        }
    }
}