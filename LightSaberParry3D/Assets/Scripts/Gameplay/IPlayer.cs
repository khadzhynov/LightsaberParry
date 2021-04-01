using System;
using UnityEngine;

namespace LightsaberParry.Gameplay
{
    public interface IPlayer
    {
        event Action OnSwingDone;
        event Action OnReadyToSwing;
        SaberStateDto GetPlayerState();
        void SwingToTarget(Quaternion targetPivotRotation);
    }
}