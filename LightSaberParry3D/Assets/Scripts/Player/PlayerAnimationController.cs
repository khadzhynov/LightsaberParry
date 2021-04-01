using UnityEngine;
using DG.Tweening;
using System;
using Zenject;

namespace LightsaberParry.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        public event Action OnSwingDone;
        public event Action OnReadyToSwing;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _leftHandAnchor;

        [SerializeField]
        private Transform _rightHandAnchor;

        [SerializeField]
        private Transform _rotationControl;

        [SerializeField]
        private Transform _saberPivot;

        [SerializeField]
        private Transform _saberPivotStartAnchor;

        private PlayerAnimationModel _model;

        private int _hitTrigger = Animator.StringToHash("Hit");
        private int _idleTrigger = Animator.StringToHash("Idle");

        [Inject]
        public void Construct(PlayerAnimationModel model)
        {
            _model = model;
        }

        private void Start()
        {
            _saberPivot.rotation = _saberPivotStartAnchor.rotation;
        }

        public void PlaySwingAnimation(Quaternion targetRotation)
        {
            _animator.SetTrigger(_hitTrigger);

            _saberPivot.DORotateQuaternion(targetRotation, _model.SwingAnimationDuration)
                .SetEase(Ease.InSine)
                .OnComplete(SwingDone);
        }

        private void SwingDone()
        {
            _animator.SetTrigger(_idleTrigger);
            OnSwingDone?.Invoke();
            _saberPivot.DORotateQuaternion(_saberPivotStartAnchor.rotation, _model.ReturnAnimationDuration)
                .OnComplete(() => OnReadyToSwing?.Invoke());
        }

        public void SetSaberAngle(float angle)
        {
            Vector3 rotation = _rotationControl.localRotation.eulerAngles;
            rotation.z = angle;
            _rotationControl.localRotation = Quaternion.Euler(rotation);
        }

        private void OnAnimatorIK()
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _model.RightHandIKWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _model.RightHandIKWeight);

            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _model.LeftHandIKWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _model.LeftHandIKWeight);

            _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandAnchor.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandAnchor.rotation);
            
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandAnchor.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandAnchor.rotation);
        }
    }
}