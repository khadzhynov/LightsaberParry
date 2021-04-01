using System;
using UnityEngine;

namespace LightsaberParry.Gameplay
{
    [Serializable]
    public struct PredictionResult
    {
        public readonly bool Collide;
        public readonly Vector3 CollisionPoint;
        public readonly Quaternion Rotation1;
        public readonly Quaternion Rotation2;

        public PredictionResult(bool collide, Vector3 collisionPoint, Quaternion rotation1, Quaternion rotation2)
        {
            Collide = collide;
            CollisionPoint = collisionPoint;
            Rotation1 = rotation1;
            Rotation2 = rotation2;
        }
    }
}