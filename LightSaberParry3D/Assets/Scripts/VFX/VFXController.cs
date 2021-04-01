using LightsaberParry.Gameplay;
using UnityEngine;

namespace LightsaberParry.Vfx
{
    public class VfxController : IVfxController
    {
        private VfxModel _vfxModel;

        public VfxController(VfxModel vfxModel)
        {
            _vfxModel = vfxModel;
        }

        public void SpawnSaberCollisionEffect(Vector3 position)
        {
            Object.Instantiate(_vfxModel.SaberCollision, position, Quaternion.identity);
        }
    }
}