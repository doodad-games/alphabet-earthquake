using UnityEngine;
using UnityEngine.Events;

public class DoCallbacksForLifecycle : MonoBehaviour
{
    public UnityEvent AwakeCallbacks;
    public UnityEvent OnEnableCallbacks;
    public UnityEvent OnDisableCallbacks;
    public UnityEvent OnDestroyCallbacks;

    public void Awake() =>
        AwakeCallbacks?.Invoke();

    public void OnEnable() =>
        OnEnableCallbacks?.Invoke();

    public void OnDisable()
    {
        if (!ApplicationSettings.Quitting)
            OnDisableCallbacks?.Invoke();
    }

    public void OnDestroy()
    {
        if (!ApplicationSettings.Quitting)
            OnDestroyCallbacks?.Invoke();
    }
}
