using _Game._Scripts.Core.UI;
using _Game._Scripts.Features.Multitool;
using _Game._Scripts.Features.Player.Movement;
using UnityEngine;
using Zenject;

namespace _Game._Scripts.Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerWorldUI playerWorldUI;
        
        public override void InstallBindings()
        {
            Container.Bind<IMovement>().To<Movement>().AsSingle();
            Container.Bind<IMultitool>().To<Multitool>().AsSingle();
            
            Container.Bind<PlayerWorldUI>().FromInstance(playerWorldUI).AsSingle();
        }
    }
}
