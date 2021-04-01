using LightsaberParry.Utils;

namespace LightsaberParry.Gameplay
{
    public interface IAngleSource
    {
        IReactivePropertyEvent<float> this[int i] { get; }
    }
}