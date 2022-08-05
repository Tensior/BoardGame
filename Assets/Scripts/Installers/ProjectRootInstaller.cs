using Meta;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectRootInstaller : MonoInstaller
    {
        [SerializeField] private MusicController _musicController;
        public override void InstallBindings()
        {
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle().NonLazy();
            Container.Bind<IMusicController>().To<MusicController>().FromInstance(_musicController).AsSingle().NonLazy();
        }
    }
}