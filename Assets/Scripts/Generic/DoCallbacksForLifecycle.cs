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

    public void OnDisable() =>
        OnDisableCallbacks?.Invoke();

    public void OnDestroy() =>
        OnDestroyCallbacks?.Invoke();
}
