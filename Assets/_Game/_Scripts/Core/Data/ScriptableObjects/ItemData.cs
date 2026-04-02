using UnityEngine;

namespace _Game._Scripts.Core.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "MarsObjects/Item/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private string description;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Sprite icon;
        [SerializeField] private Color color;
        [SerializeField] private bool stackable;

        public string ItemName => name;
        public string Description => description;
        public GameObject Prefab => prefab;
        public Sprite Icon => icon;
        public Color Color => color;
        public bool Stackable => stackable;
    }

}
