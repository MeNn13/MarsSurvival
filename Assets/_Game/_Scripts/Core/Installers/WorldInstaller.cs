using _Game._Scripts.Core.World;
using Zenject;
namespace _Game._Scripts.Core.Installers
{
    public class WorldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IWorldData>().To<WorldData>().AsSingle().NonLazy();
        }
    }
}