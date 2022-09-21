using UnityEngine;
using UnityEngine.Events;

public class DoCallbacksOnColliderTrigger : MonoBehaviour
{
    public UnityEvent Callbacks;

    public void OnTriggerEnter(Collider other) =>
        Callbacks?.Invoke();
}
