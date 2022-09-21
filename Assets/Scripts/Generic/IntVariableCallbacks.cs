using UnityEngine;

public class IntVariableCallbacks : MonoBehaviour
{
    public IntVariable Variable;

    public void CB_Increment() =>
        Variable.RuntimeValue++;

    public void CB_Decrement() =>
        Variable.RuntimeValue--;

    public void CB_SetValue(int value) =>
        Variable.RuntimeValue = value;
}
