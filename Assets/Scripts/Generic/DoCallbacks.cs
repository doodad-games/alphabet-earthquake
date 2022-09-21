using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoCallbacks : MonoBehaviour
{
    public bool ExecuteOnEnable;
    public float Delay;
    public TimeType DelayType; 
    public UnityEvent Callbacks;

    public void OnEnable()
    {
        if (ExecuteOnEnable)
            CB_Execute();
    }

    public void CB_Execute()
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
