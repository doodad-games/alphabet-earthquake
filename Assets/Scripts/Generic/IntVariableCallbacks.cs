using UnityEngine;

public class IntVariableCallbacks : MonoBehaviour
{
    public IntVariable Variable;

    public void CB_IncrementIntVariable() =>
        Variable.RuntimeValue++;

    public void CB_DecrementIntVariable() =>
        Variable.RuntimeValue--;

    public void CB_SetIntVariable(int value) =>
        Variable.RuntimeValue = value;
}
