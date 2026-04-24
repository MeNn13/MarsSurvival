using System;
using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.Data.Entities
{
    [Serializable]
    public class ItemEntity
    {
        [field: SerializeField] public ItemData ItemData { get; private set; }
        [field: SerializeField] public int Count { get; private set; } = 1;
        
        public bool IsEmpty => Count <= 0;

        public ItemEntity() { }

        public ItemEntity(ItemData itemData)
        {
            ItemData = itemData;
        }

        public void Add(int amount)
        {
            if (amount <= 0) return;
            Count += amount;
        }

        public void Remove(int amount)
        {
            if (amount <= 0) return;
            Count = Math.Max(0, Count - amount);
        }

        public void SetCount(int newCount)
        {
            Count = Math.Max(0, newCount);
        }
    }
}
