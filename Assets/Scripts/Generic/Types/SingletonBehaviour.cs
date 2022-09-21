using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class SingletonBehaviour<T> : MonoBehaviour
    where T : SingletonBehaviour<T>
{
    static T _i;
    static bool _initialised;

#if UNITY_EDITOR
    static SingletonBehaviour() =>
        EditorApplication.playModeStateChanged += (@event) =>
        {
            if (@event == PlayModeStateChange.EnteredEditMode)
                _initialised = false;
        };
#endif

    /// <summary>This can be null during application teardown.</summary>
    public static T I
    {
        get
        {
            if (!_initialised && _i == null)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                    throw new InvalidOperationException();
#endif

                _initialised = true;
                CreateInstance();
            }

            return _i;
        }
    }

    static void CreateInstance()
    {
        var gameObject = new GameObject(typeof(T).Name);
        gameObject.hideFlags = HideFlags.HideInHierarchy;
        DontDestroyOnLoad(gameObject);
        gameObject.AddComponent<T>()
            .SingletonInit();
    }

    public virtual void OnEnable()
    {
        if (_i != null && _i != this)
        {
            Debug.LogError($"Duplicate singleton ({typeof(T).Name}) created, self-destructing!");
            DestroyImmediate(gameObject);
            return;
        }

        _i = (T)this;
    }

    protected virtual void SingletonInit() { }
}
