using UnityEngine;

/**
 * ## Notes
 *
 * - Runtime changes to Variable are not supported, except if done while this component is disabled.
 * - y = mx + b formula applied: x = Variable.RuntimeValue; y = Output value.
 */

public class DoScaledCallbacksForIntVariable : MonoBehaviour
{
    public IntVariable Variable;
    public float M;
    public float B;

    [Space(10)]
    public UnityEventFloat ChangedCallback;

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

    void HandleValueChanged(int value) =>
        ChangedCallback?.Invoke(M * value + B);
}
