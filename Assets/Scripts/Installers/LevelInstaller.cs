using Core;
using Core.Map;
using Core.Players;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Transform _nodesRoot;
        [SerializeField] private Player[] _players;
        public override void InstallBindings()
        {
            Container.Bind<IPlayersProvider>().To<PlayersProvider>().AsSingle().NonLazy();
            Container.Bind<Player[]>().FromInstance(_players).WhenInjectedInto<PlayersProvider>().NonLazy();

            Container.BindInterfacesTo<MapManager>().AsSingle().NonLazy();
            Container.Bind<Transform>().FromInstance(_nodesRoot).WhenInjectedInto<MapManager>().NonLazy();
        }
    }
}