using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.Blocks.Factories
{
    public class BlockFactory : IBlockFactory
    {

        public Block Create(BlockData data, Vector2Int position)
        {
            var block = new Block(data);
            
            //Добаление блока в систему

            return block;
        }
        
        public Block CreateMultiBlock(BlockData data, Vector2Int[] positions)
        {
            var block = new MultiBlock(data, positions);
            
            return block;
        }
    }
}
