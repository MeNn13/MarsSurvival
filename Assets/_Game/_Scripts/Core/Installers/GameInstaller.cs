using _Game._Scripts.Features.Overload;
using _Game._Scripts.Features.Oxygen;
using Zenject;

namespace _Game._Scripts.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IOxygen>().To<Oxygen>().AsTransient();
            Container.Bind<IOverload>().To<Overload>().AsTransient();
        }
    }
}
