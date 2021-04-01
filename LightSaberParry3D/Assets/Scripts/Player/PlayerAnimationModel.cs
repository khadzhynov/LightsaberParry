using UnityEngine;

namespace LightsaberParry.Player
{
    [CreateAssetMenu]
    public class PlayerAnimationModel : ScriptableObject
    {
        [SerializeField]
        private bool _holdSaberWithLeftHand = true;

        [SerializeField]
        private bool _holdSaberWithRightHand = true;

        [SerializeField]
        private float _swingAnimationDuration = 0.25f;

        [SerializeField]
        private float _returnAnimationDuration = 0.75f;

        public float RightHandIKWeight => _holdSaberWithRightHand ? 1 : 0;
        public float LeftHandIKWeight => _holdSaberWithLeftHand ? 1 : 0;
        public float SwingAnimationDuration => _swingAnimationDuration;
        public float ReturnAnimationDuration => _returnAnimationDuration;
    }
}