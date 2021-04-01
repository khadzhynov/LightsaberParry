using UnityEngine;

namespace LightsaberParry.Services
{
    [CreateAssetMenu]
    public class CollisionPredictionSettings : ScriptableObject
    {
        [SerializeField]
        private float _saberWidth = 0.2f;

        [Tooltip("How many positions inside one swing trajectory would be tested. Interpolation is linear.")]
        [SerializeField]
        private int _interpolationSteps = 45;

        public float SaberWidth => _saberWidth;
        public int InterpolationSteps => _interpolationSteps;
    }
}