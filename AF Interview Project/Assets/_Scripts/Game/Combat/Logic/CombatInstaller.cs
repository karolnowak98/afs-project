using UnityEngine;
using Zenject;
using AFSInterview.Game.Combat.Data;

namespace AFSInterview.Game.Combat.Logic
{
    public class CombatInstaller : MonoInstaller
    {
        [SerializeField] private CombatConfig _combatConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_combatConfig).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CombatManager>().AsSingle();
        }
    }
}