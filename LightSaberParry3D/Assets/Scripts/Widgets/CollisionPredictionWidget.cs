using LightsaberParry.Gameplay;
using UnityEngine;
using Zenject;

namespace LightsaberParry.Widgets
{
    public class CollisionPredictionWidget : MonoBehaviour
    {
        private GameplayModel _gameplayModel;

        [SerializeField]
        private GameObject _collide;

        [SerializeField]
        private GameObject _notCollide;

        [Inject]
        public void Construct(GameplayModel gameplayModel)
        {
            _gameplayModel = gameplayModel;
        }

        private void OnEnable()
        {
            _gameplayModel.WillCollide.OnValueChanged += OnWillCollideValueChangedHandler;
        }
        private void OnDisable()
        {
            _gameplayModel.WillCollide.OnValueChanged += OnWillCollideValueChangedHandler;
        }

        private void OnWillCollideValueChangedHandler(bool willCollide)
        {
            _collide.SetActive(willCollide);
            _notCollide.SetActive(!willCollide);
        }
    }
}