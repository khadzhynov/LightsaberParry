using LightsaberParry.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace LightsaberParry.Gameplay
{
    [CreateAssetMenu]
    public class GameplayModel : ScriptableObject, IAngleSource
    {
        [SerializeField]
        private List<ReactiveFloat> _playerAngles;

        [SerializeField]
        private ReactiveBool _willCollide;

        public ReactiveBool WillCollide { get => _willCollide; set => _willCollide = value; }
        public List<ReactiveFloat> PlayerAngles { get => _playerAngles; set => _playerAngles = value; }
        public PredictionResult LastPredictionResult { get; set; }

        public IReactivePropertyEvent<float> this[int i] => _playerAngles[i];

        public void Reset()
        {
            _willCollide.Value = false;
        }
    }
}