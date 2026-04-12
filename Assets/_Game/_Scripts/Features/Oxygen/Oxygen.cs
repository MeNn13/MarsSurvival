using UnityEngine;

namespace _Game._Scripts.Features.Oxygen
{
    public class Oxygen : IOxygen
    {
        public float Store
        {
            get => _store;
            private set => _store = _store > MaxStore ? MaxStore : value;
        }
        public int MaxStore { get; private set; }

        private float _store;

        public void Initialize(int maxStore, float store)
        {
            MaxStore = maxStore;
            Store = store;
        }

        public void Supply(int count)
        {
            if (Mathf.Approximately(Store, MaxStore))
                return;

            Store += count * Time.deltaTime;
        }

        public void Spend(int count)
        {
            if (Mathf.Approximately(Store, 0))
            {
                //TODO: Предупреждаем, что закончился кислород
                return;
            }

            Store -= count * Time.deltaTime;
        }
    }
}
