namespace _Game._Scripts.Features.Timer
{
    public interface ITimer
    {
        float Time { get; }
        float CurrentTime { get; }
        
        void Update(float time);
        
        bool Calculate();
    }
}
