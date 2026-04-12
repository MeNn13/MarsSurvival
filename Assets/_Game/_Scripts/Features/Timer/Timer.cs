namespace _Game._Scripts.Features.Timer
{
    public class Timer : ITimer
    {
        public float Time { get; private set; }
        public float CurrentTime { get; private set; }
        
        public void Update(float time)
        {
            Time = time;
            CurrentTime = time;
        }
        
        public bool Calculate()
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= UnityEngine.Time.deltaTime;
                return  true;
            }

            return false;
        }
    }
}
