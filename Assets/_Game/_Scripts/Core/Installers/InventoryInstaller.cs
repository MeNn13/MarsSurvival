using _Game._Scripts.Features.Inventory;
using _Game._Scripts.Features.Inventory.Item;
using UnityEngine;
using Zenject;

namespace _Game._Scripts.Core.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private ItemView itemViewPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<ItemView>().FromInstance(itemViewPrefab).AsSingle();
            
            Container.Bind<IItemManager>().To<ItemManager>().AsSingle();
            Container.Bind<IInventory>().To<Inventory>().AsSingle();
        }
    }
}
