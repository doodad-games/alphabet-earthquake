using UnityEngine;
using UnityEngine.Events;

/**
 * ## Notes
 *
 * - Runtime changes to Event are not supported, except if done while this component is disabled.
 */

public class DoCallbacksOnGameEvent : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Callbacks;

    public void OnEnable()
    {
        if (Event != null)
            Event.OnEvent += HandleEvent;
    }

    public void OnDisable()
    {
        if (Event != null)
            Event.OnEvent -= HandleEvent;
    }

    void HandleEvent() =>
        Callbacks?.Invoke();
}
