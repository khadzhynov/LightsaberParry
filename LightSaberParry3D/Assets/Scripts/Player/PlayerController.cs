using LightsaberParry.Gameplay;
using System;
using UnityEngine;
using Zenject;

namespace LightsaberParry.Player
{
    public class PlayerController : MonoBehaviour, IPlayer
    {
        public event Action OnSwingDone;
        public event Action OnReadyToSwing;

        [SerializeField]
        private PlayerAnimationController _playerAnimation;

        private IAngleSource _angleSource;

        [SerializeField]
        private int _playerIndex;

        [SerializeField]
        private Transform _pivot;

        [SerializeField]
        private Transform _saberBegin;

        [SerializeField]
        private Transform _saberEnd;

        [SerializeField]
        private Transform _pivotEndAnchor;

        [Inject]
        public void Construct(
            IAngleSource angleSource)
        {
            _angleSource = angleSource;
        }

        private void OnEnable()
        {
            _angleSource[_playerIndex].OnValueChanged += OnPlayerAngleChangedHandler;
            _playerAnimation.OnSwingDone += OnSwingDone;
            _playerAnimation.OnReadyToSwing += OnReadyToSwing;
        }

        private void OnDisable()
        {
            _angleSource[_playerIndex].OnValueChanged -= OnPlayerAngleChangedHandler;
            _playerAnimation.OnSwingDone -= OnSwingDone;
            _playerAnimation.OnReadyToSwing -= OnReadyToSwing;
        }

        private void OnPlayerAngleChangedHandler(float angle)
        {
            _playerAnimation.SetSaberAngle(angle);
        }

        public SaberStateDto GetPlayerState()
        {
            float saberBeginDistance = Vector3.Distance(_pivot.position, _saberBegin.position);
            float saberEndDistance = Vector3.Distance(_pivot.position, _saberEnd.position);

            return new SaberStateDto(
                _pivot,
                _pivotEndAnchor,
                _saberBegin,
                _saberEnd);
        }

        public void SwingToTarget(Quaternion targetPivotRotation)
        {
            _playerAnimation.PlaySwingAnimation(targetPivotRotation);
        }
    }
}

