using System;

namespace LightsaberParry.Gameplay
{
    public class GameplayController : IDisposable
    {
        public event Action OnSimulationOver;

        private IPredictionService _predictionService;
        private IPlayerInputListener _playerInputListener;
        private GameplayModel _gameplayModel;
        private PlayersList _players;
        private IVfxController _vfxController;

        public GameplayController(
            IPredictionService predictionService, 
            IPlayerInputListener playerInputListener, 
            GameplayModel gameplayModel, 
            PlayersList players,
            IVfxController vfxController)
        {
            _predictionService = predictionService;
            _playerInputListener = playerInputListener;
            _gameplayModel = gameplayModel;
            _players = players;
            _vfxController = vfxController;

            _playerInputListener.OnInputUpdate += OnInputUpdateHandler;

            _players[0].OnSwingDone += OnSwingDone;
            _players[0].OnReadyToSwing += OnReadyToSwing;

            _gameplayModel.Reset();
        }

        private void OnReadyToSwing()
        {
            OnSimulationOver?.Invoke();
            _playerInputListener.SetEnabled(true);
        }

        private void OnSwingDone()
        {
            if (_gameplayModel.LastPredictionResult.Collide)
            {
                _vfxController.SpawnSaberCollisionEffect(_gameplayModel.LastPredictionResult.CollisionPoint);
            }
        }

        public void SimulatePressed()
        {
            _playerInputListener.SetEnabled(false);
            _players[0].SwingToTarget(_gameplayModel.LastPredictionResult.Rotation1);
            _players[1].SwingToTarget(_gameplayModel.LastPredictionResult.Rotation2);
        }

        private void OnInputUpdateHandler(int index, float angle)
        {
            _gameplayModel.PlayerAngles[index].Value = angle;

            var collisionPredictionResult = _predictionService.PredictCollision(
                _players[0].GetPlayerState(),
                _players[1].GetPlayerState());

            _gameplayModel.LastPredictionResult = collisionPredictionResult;
            _gameplayModel.WillCollide.Value = collisionPredictionResult.Collide;
        }

        public void Dispose()
        {
            if (_playerInputListener != null)
            {
                _playerInputListener.OnInputUpdate -= OnInputUpdateHandler;
            }

            if (_players[0] != null)
            {
                _players[0].OnSwingDone -= OnSwingDone;
                _players[0].OnReadyToSwing -= OnReadyToSwing;
            }
        }
    }
}