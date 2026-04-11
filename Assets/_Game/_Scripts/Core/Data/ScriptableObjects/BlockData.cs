using UnityEngine;

namespace _Game._Scripts.Core.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BlockData", menuName = "MarsObjects/Item/BlockData")]
    public class BlockData : ItemData
    {
        [SerializeField] private float timeToDestroy;
        [SerializeField] private ModifierData[] modifierToMine;
        [SerializeField] private RuleTile ruleTile;

        public float TimeToDestroy => timeToDestroy;
        public RuleTile Tile => ruleTile;
        public ModifierData[] ModifierToMine => modifierToMine;
    }
}
