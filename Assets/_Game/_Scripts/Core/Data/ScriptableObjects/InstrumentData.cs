using UnityEngine;

namespace _Game._Scripts.Core.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "InstrumentData", menuName = "MarsObjects/Item/InstrumentData")]
    public class InstrumentData : ItemData
    {
        [SerializeField] private float speed;
        public float Speed => speed;
    }
}
