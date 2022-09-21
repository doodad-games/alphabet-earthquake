using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScriptableValue<T> : ScriptableObject, ISerializationCallbackReceiver
{
#if UNITY_EDITOR
    static bool _hookedIntoModeChange;
#endif


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
