using System;
using _Game._Scripts.Core.Data.ScriptableObjects;

namespace _Game._Scripts.Core.Data.Entities
{
    [Serializable]
    public class ItemEntity
    {
        public ItemData itemData;
        public int count = 1;
        
        public ItemEntity() { }
        public ItemEntity(ItemData itemData) {
            this.itemData = itemData;
        }
    }
}
