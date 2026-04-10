using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.Blocks
{
    public class MultiBlock : Block
    {
        private readonly Vector2Int[] _blockPositions;

        public MultiBlock(BlockData blockData, Vector2Int[] blockPositions) : base(blockData)
        {
            _blockPositions = blockPositions;
        }
    }
}
