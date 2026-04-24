using _Game._Scripts.Features.Inventory;
using _Game._Scripts.Features.Inventory.Item;
using _Game._Scripts.Features.Inventory.Item.Factories;
using UnityEngine;
using Zenject;

namespace _Game._Scripts.Core.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private ItemView itemViewPrefab;
        [SerializeField] private Transform dragArea;
        
        public override void InstallBindings()
        {
            Container.Bind<IItemViewFactory>()
                .To<ItemViewFactory>()
                .AsSingle()
                .WithArguments(itemViewPrefab, dragArea);

            Container.Bind<IInventory>().To<Inventory>().AsSingle();
        }
    }
}
