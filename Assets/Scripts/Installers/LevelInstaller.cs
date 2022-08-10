using Cinemachine;
using Core;
using Core.Camera;
using Core.Map;
using Core.Players;
using UnityEngine;
using Zenject;
using CameraType = Core.Camera.CameraType;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Transform _nodesRoot;
        [SerializeField] private CinemachineVirtualCamera _overviewCamera;
        [SerializeField] private CinemachineVirtualCamera _playerCamera;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MapProvider>().AsSingle().NonLazy();
            Container.Bind<Transform>().FromInstance(_nodesRoot).WhenInjectedInto<MapProvider>().NonLazy();

            Container.Bind<ICameraController>().To<CameraController>().AsSingle().NonLazy();
            Container.Bind<CinemachineVirtualCamera>().WithId(CameraType.Overview).FromInstance(_overviewCamera).AsCached().NonLazy();
            Container.Bind<CinemachineVirtualCamera>().WithId(CameraType.Player).FromInstance(_playerCamera).AsCached().NonLazy();
        }
    }
}