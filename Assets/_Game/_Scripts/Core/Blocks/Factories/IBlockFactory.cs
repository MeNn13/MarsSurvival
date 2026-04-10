using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.Blocks.Factories
{
    public interface IBlockFactory
    {
        Block Create(BlockData data, Vector2Int position);
        Block CreateMultiBlock(BlockData data, Vector2Int[] positions);
    }
}
