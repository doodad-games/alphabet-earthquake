using UnityEngine;

public class ApplyRotationContinuously : MonoBehaviour
{
    public Quaternion Rotation;

    public void Update() =>
        transform.rotation *= Quaternion.Slerp(Quaternion.identity, Rotation, Time.deltaTime);
}
