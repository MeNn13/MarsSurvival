using _Game._Scripts.Features.Player.Movement;
using Zenject;

namespace _Game._Scripts.Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMovement>().To<Movement>().AsSingle();
        }
    }
}
