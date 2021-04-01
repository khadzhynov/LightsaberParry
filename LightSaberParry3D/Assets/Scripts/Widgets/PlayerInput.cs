using LightsaberParry.Gameplay;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LightsaberParry.Widgets
{
    public class PlayerInput : MonoBehaviour, IPlayerInputListener
    {
        public event Action<int, float> OnInputUpdate;

        [SerializeField]
        private List<Slider> _sliders;

        private void Start()
        {
            for (int i = 0; i < _sliders.Count; ++i)
            {
                SliderListener(i, _sliders[i].value);
            }
        }

        private void OnEnable()
        {
            for (int i = 0; i < _sliders.Count; ++i)
            {
                int index = i;
                _sliders[i].onValueChanged.AddListener(x => SliderListener(index, x));
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _sliders.Count; ++i)
            {
                _sliders[i].onValueChanged.RemoveAllListeners();
            }
        }

        public void SetEnabled(bool isEnabled)
        {
            foreach(var slider in _sliders)
            {
                slider.interactable = isEnabled;
            }
        }

        private void SliderListener(int index, float value)
        {
            OnInputUpdate?.Invoke(index, value);
        }
    }
}