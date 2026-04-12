namespace _Game._Scripts.Features.Overload
{
    public interface IOverload
    {
        float MaxValue {get;}
        float Value {get;}
        
        void Increase(float count);
        void Reduce(float count);
    }

}
