using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;

namespace _Game._Scripts.Core.Data
{
    [CreateAssetMenu(fileName = "RuleTileData", menuName = "MarsObjects/Data Rule Tile")]
    public class RuleTileData : RuleTile
    {
        [SerializeField] private BlockData blockData;
        
        public BlockData BlockData => blockData;
    }
}
