using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScriptableValue<T> : ScriptableObject, ISerializationCallbackReceiver
{
    public event Action<T> OnValueChanged;

    public T InitialValue;

    T _runtimeValue;

#if UNITY_EDITOR
    [NonSerialized] bool _hookedIntoModeChange;
#endif

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

    public void OnAfterDeserialize()
    {
        _runtimeValue = InitialValue;

#if UNITY_EDITOR
        if (!_hookedIntoModeChange)
        {
            _hookedIntoModeChange = true;
            EditorApplication.playModeStateChanged += (stateChange) =>
            {
                if (stateChange == PlayModeStateChange.EnteredEditMode)
                    _runtimeValue = InitialValue;
            };
        }
#endif
    }
}
