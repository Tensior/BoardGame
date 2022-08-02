using Configs;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] private TurnsConfigSO _turnsConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<TurnsConfigSO>().FromInstance(_turnsConfig).AsSingle().NonLazy();
        }
    }
}