using System;
using UnityEngine;

public class ScriptableValue<T> : ScriptableObject, ISerializationCallbackReceiver
{
    public event Action<T> OnValueChanged;

    public T InitialValue;

    T _runtimeValue;

    public T RuntimeValue
    {
        get => _runtimeValue;
        set
        {
            _runtimeValue = value;
            OnValueChanged?.Invoke(value);
        }
    }

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize() =>
        _runtimeValue = InitialValue;
}
