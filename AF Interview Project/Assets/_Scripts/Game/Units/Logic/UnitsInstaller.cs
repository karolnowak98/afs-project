using UnityEngine;
using Zenject;
using AFSInterview.Game.Units.Data;

namespace AFSInterview.Game.Units.Logic
{
    public class UnitsInstaller : MonoInstaller
    {
        [SerializeField] private UnitsConfigs _configs;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_configs).AsSingle().NonLazy();
        }
    }
}