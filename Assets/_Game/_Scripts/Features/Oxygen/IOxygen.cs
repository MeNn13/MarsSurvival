namespace _Game._Scripts.Features.Oxygen
{
    public interface IOxygen
    {
        float Store { get; }
        int MaxStore { get; }

        void Initialize(int maxStore, float store);
        void Supply(int count);
        void Spend(int count);
    }
}
