using UnityEngine;

public class Counter : MonoBehaviour
{
    public int Threshold;

    [Space(10)]
    public UnityEventInt ChangedCallback;
    public UnityEventInt LessThanThresholdCallback;
    public UnityEventInt EqualToThresholdCallback;
    public UnityEventInt GreaterThanThresholdCallback;

    int _value;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            ExecuteCallbacks();
        }
    }

    public void CB_Increment() =>
        Value++;

    public void CB_ResetWithoutExecutingThresholds()
    {
        _value = 0;
        ChangedCallback?.Invoke(_value);
    }

    void ExecuteCallbacks()
    {
        ChangedCallback?.Invoke(_value);
        if (_value < Threshold)
            LessThanThresholdCallback?.Invoke(_value);
        else if (_value == Threshold)
            EqualToThresholdCallback?.Invoke(_value);
        else GreaterThanThresholdCallback?.Invoke(_value);
    }
}
