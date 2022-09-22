using UnityEngine;

public class Vector3VariableCallbacks : MonoBehaviour
{
    public Vector3Variable Variable;
    public UnityEventVector3 PassThroughCallbacks;

    public void CB_DoPassThroughCallbacks() =>
        PassThroughCallbacks?.Invoke(Variable.RuntimeValue);

    public void CB_SetVector3Variable(Vector3 value) =>
        Variable.RuntimeValue = value;
}
