using UnityEngine;

namespace _Game._Scripts.Core.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BlockData", menuName = "MarsObjects/Item/BlockData")]
    public class BlockData : ItemData
    {
        [SerializeField] private float timeToDestroy;
        [SerializeField] private int instrumentLevel;
        [SerializeField] private RuleTile ruleTile;

        public float TimeToDestroy => timeToDestroy;
        public int InstrumentLevel => instrumentLevel;
        public RuleTile Tile => ruleTile;
    }
}
