using UnityEngine;

namespace LightsaberParry.Vfx
{
    [CreateAssetMenu]
    public class VfxModel : ScriptableObject
    {
        [SerializeField]
        private ParticleSystem _saberCollision;

        public ParticleSystem SaberCollision => _saberCollision;
    }
}