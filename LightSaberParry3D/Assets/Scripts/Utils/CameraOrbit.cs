using UnityEngine;
using UnityEngine.EventSystems;

namespace LightsaberParry.Utils
{
    public class CameraOrbit : MonoBehaviour, IDragHandler
    {
        [SerializeField]
        private Transform _camera;

        [SerializeField]
        private Transform _target;

        [SerializeField]
        private float _sensitivity = 0.1f;

        public void OnDrag(PointerEventData eventData)
        {
            _camera.RotateAround(_target.position, Vector3.up, eventData.delta.x * _sensitivity);
            _camera.RotateAround(_target.position, _camera.right, -eventData.delta.y * _sensitivity);
        }
    }
}