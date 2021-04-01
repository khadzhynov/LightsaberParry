using LightsaberParry.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LightsaberParry.Widgets
{
    public class SimulateWidget : MonoBehaviour
    {
        private GameplayController _gameplayController;

        [SerializeField]
        private Button _simulateButton;

        [Inject]
        public void Construct(GameplayController gameplayController)
        {
            _gameplayController = gameplayController;
        }

        private void OnEnable()
        {
            _simulateButton.onClick.AddListener(ButtonListener);
            _gameplayController.OnSimulationOver += OnSimulationOverHandler;
        }

        private void OnDisable()
        {
            _simulateButton.onClick.RemoveListener(ButtonListener);
            _gameplayController.OnSimulationOver -= OnSimulationOverHandler;
        }

        private void ButtonListener()
        {
            _simulateButton.interactable = false;
            _gameplayController.SimulatePressed();
        }

        private void OnSimulationOverHandler()
        {
            _simulateButton.interactable = true;
        }
    }
}