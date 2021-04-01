using LightsaberParry.Gameplay;
using LightsaberParry.Player;
using LightsaberParry.Services;
using LightsaberParry.Vfx;
using LightsaberParry.Widgets;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LightsaberParry.CompositionRoot
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField]
        private GameplayModel _gameplayModel;

        [SerializeField]
        private List<PlayerController> _players;

        [SerializeField]
        private PlayerInput _playerInput;

        [SerializeField]
        private SimulateWidget _simulateWidget;

        [SerializeField]
        private CollisionPredictionWidget _collisionPredictionWidget;

        [SerializeField]
        private CollisionPredictionSettings _collisionPredictionSettings;

        [SerializeField]
        private VfxModel _vfxModel;

        [SerializeField]
        private PlayerAnimationModel _playerAnimationModel;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplayController>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameplayModel>().FromInstance(_gameplayModel).AsSingle().NonLazy();

            var playerList = new PlayersList();
            playerList.AddRange(_players);
            Container.BindInterfacesAndSelfTo<PlayersList>().FromInstance(playerList).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerInput>().FromInstance(_playerInput).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<SimulateWidget>().FromInstance(_simulateWidget).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CollisionPredictionWidget>().FromInstance(_collisionPredictionWidget).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CollisionPredictionService>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CollisionPredictionSettings>().FromInstance(_collisionPredictionSettings).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<VfxController>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<VfxModel>().FromInstance(_vfxModel).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerAnimationModel>().FromInstance(_playerAnimationModel).AsSingle().NonLazy();
        }

    }
}