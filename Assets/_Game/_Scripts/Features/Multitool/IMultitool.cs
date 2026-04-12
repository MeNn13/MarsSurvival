namespace _Game._Scripts.Features.Multitool
{
    public interface IMultitool
    {
        MultitoolMode Mode {get; set;}

        void Update();
        void Use();
    }
}
