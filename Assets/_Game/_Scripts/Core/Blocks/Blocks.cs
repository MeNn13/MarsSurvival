using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.Blocks
{
    public class Block
    {
        private readonly BlockData _blockData;

        private float _currentDestroyTime;

        public Block(BlockData blockData)
        {
            _blockData = blockData;
        }

        public bool Destruction(float speedToDestroy)
        {
            if (_currentDestroyTime < _blockData.TimeToDestroy)
            {
                _currentDestroyTime += speedToDestroy + Time.deltaTime;
                return true;
            }

            return false;
        }
    }

}
