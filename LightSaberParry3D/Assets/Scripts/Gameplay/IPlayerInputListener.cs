using System;

namespace LightsaberParry.Gameplay
{
    public interface IPlayerInputListener
    {
        event Action<int, float> OnInputUpdate;
        void SetEnabled(bool isEnabled);
    }
}