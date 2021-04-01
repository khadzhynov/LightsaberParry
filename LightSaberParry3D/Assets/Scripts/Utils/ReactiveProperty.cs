using System;
using UnityEngine;

namespace LightsaberParry.Utils
{
    public interface IReactivePropertyEvent<T>
    {
        event Action<T> OnValueChanged;
    }

    [Serializable] public class ReactiveBool : ReactiveProperty<bool>, IReactivePropertyEvent<bool> { }
    [Serializable] public class ReactiveInt : ReactiveProperty<int>, IReactivePropertyEvent<int> { }
    [Serializable] public class ReactiveFloat : ReactiveProperty<float>, IReactivePropertyEvent<float> { }
    [Serializable] public class ReactiveString : ReactiveProperty<string>, IReactivePropertyEvent<string> { }
    [Serializable] public class ReactiveVector3 : ReactiveProperty<Vector3>, IReactivePropertyEvent<Vector3> { }
    [Serializable] public class ReactiveVector2 : ReactiveProperty<Vector2>, IReactivePropertyEvent<Vector2> { }
    [Serializable] public class ReactiveVector2Int : ReactiveProperty<Vector2Int>, IReactivePropertyEvent<Vector2Int> { }
    [Serializable] public class ReactiveVectorRect : ReactiveProperty<Rect>, IReactivePropertyEvent<Rect> { }
    [Serializable] public class ReactiveVectorBounds : ReactiveProperty<Bounds>, IReactivePropertyEvent<Bounds> { }

    public class ReactiveProperty<T> : IReactivePropertyEvent<T>
    {
        public event Action<T> OnValueChanged;

        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }
        }
    }
}