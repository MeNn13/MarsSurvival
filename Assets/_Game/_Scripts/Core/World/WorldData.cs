using System.Collections.Generic;
using _Game._Scripts.Core.Blocks;
using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.World
{
    public class WorldData : IWorldData
    {
        private readonly Dictionary<Vector2Int, Block> _blocks = new();

        public void GenerateBlocks(Dictionary<Vector2Int, BlockData> blockPositions)
        {
            foreach (var blockPos in blockPositions)
            {
                var block = new Block(blockPos.Value);
                
                _blocks.Add(blockPos.Key, block);
            }
        }
    }
}
