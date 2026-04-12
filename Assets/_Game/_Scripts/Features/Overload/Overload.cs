using UnityEngine;

namespace _Game._Scripts.Features.Overload
{
    public class Overload : IOverload
    {
        public float MaxValue => 20; 
        public float Value { get; private set; }
        
        public void Increase(float count)
        {
            if (Value >= MaxValue)
            {
                //TODO: Перегрузка взрыв!!!
                return;
            }
            
            Value += count * Time.deltaTime;
        }
        
        public void Reduce(float count)
        {
            if (Value <= 0)
            {
                Value = 0;
                return;
            }
            
            Value -= count * Time.deltaTime;
        }
    }
}
