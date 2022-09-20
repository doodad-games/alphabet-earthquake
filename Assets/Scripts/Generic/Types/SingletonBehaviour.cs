using System;
using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour
    where T : SingletonBehaviour<T>
{
    static T _i;
    public static T I
    {
        get
        {
            if (_i == null)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                    throw new InvalidOperationException();
#endif

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
        gameObject.AddComponent<T>();
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
}
