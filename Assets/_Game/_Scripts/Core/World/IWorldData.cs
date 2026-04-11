using System.Collections.Generic;
using _Game._Scripts.Core.Blocks;
using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.World
{
    public interface IWorldData
    {
        void GenerateBlocks(Dictionary<Vector2Int, BlockData> blocks);
    }
}
