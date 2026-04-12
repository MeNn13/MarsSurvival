using _Game._Scripts.Core.UI;
using _Game._Scripts.Features.Overload;
using UnityEngine;

namespace _Game._Scripts.Features.Multitool
{
    public class Multitool : IMultitool
    {
        public MultitoolMode Mode { get; set; }

        private float _overloadIncrease = 5;
        private float _overloadReduce = 2;

        private readonly IOverload _overload;
        private readonly PlayerWorldUI _playerWorldUI;

        public Multitool(IOverload overload,
            PlayerWorldUI playerWorldUI)
        {
            _overload = overload;
            _playerWorldUI = playerWorldUI;
        }

        public void Update()
        {
            if (_overload.Value == 0)
                return;
            
            OverloadReduce();
        }

        public void Use()
        {
            if (Mode is MultitoolMode.Lazer)
            {
                //Пробует что то добыть

                OverloadIncrease();
            }
        }

        private void OverloadIncrease()
        {
            _overload.Increase(_overloadIncrease);
            _playerWorldUI.UpdateOverload(_overload.MaxValue, _overload.Value);
        }
        
        private void OverloadReduce()
        {
            _overload.Reduce(_overloadReduce);
            _playerWorldUI.UpdateOverload(_overload.MaxValue, _overload.Value);
        }
    }
}
