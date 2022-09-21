using UnityEngine;

/**
 * ## Notes
 *
 * - Runtime changes to Variable are not supported, except if done while this component is disabled.
 */

public class DoCallbacksForIntVariable : MonoBehaviour
{
    public IntVariable Variable;
    public int Threshold;
    public bool ExecuteThresholdCallbacksOnChanged;

    [Space(10)]
    public UnityEventInt ChangedCallback;
    public UnityEventInt LessThanThresholdCallback;
    public UnityEventInt EqualToThresholdCallback;
    public UnityEventInt GreaterThanThresholdCallback;

    public void OnEnable()
    {
        if (Variable != null)
        {
            Variable.OnValueChanged += HandleValueChanged;
            HandleValueChanged(Variable.RuntimeValue);
        }
    }

    public void OnDisable()
    {
        if (Variable != null)
            Variable.OnValueChanged -= HandleValueChanged;
    }

    public void CB_ExecuteThresholdCallbacks()
    {
        var value = Variable.RuntimeValue;

        if (value < Threshold)
            LessThanThresholdCallback?.Invoke(value);
        else if (value == Threshold)
            EqualToThresholdCallback?.Invoke(value);
        else GreaterThanThresholdCallback?.Invoke(value);
    }

    void HandleValueChanged(int value)
    {
        ChangedCallback?.Invoke(value);

        if (ExecuteThresholdCallbacksOnChanged)
            CB_ExecuteThresholdCallbacks();
    }
}
