using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoCallbacks : MonoBehaviour
{
    public bool ActivateOnEnable;
    public float Delay;
    public TimeType DelayType; 
    public UnityEvent Callbacks;

    public void OnEnable()
    {
        if (ActivateOnEnable)
            CB_DoCallbacks();
    }

    public void CB_DoCallbacks()
    {
        if (Delay <= 0f)
            Callbacks?.Invoke();
        else StartCoroutine(ExecuteDelayed());
    }

    IEnumerator ExecuteDelayed()
    {
        if (DelayType == TimeType.Scaled)
            yield return new WaitForSeconds(Delay);
        else yield return new WaitForSecondsRealtime(Delay);

        Callbacks?.Invoke();
    }
}
