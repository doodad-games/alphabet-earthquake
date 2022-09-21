using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddForceToRigidbody : MonoBehaviour
{
    public Vector3 Force;
    public ForceMode ForceMode;

    Rigidbody _rigidbody;

    public void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    public void CB_AddForceToRigidbody()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.AddForce(Force, ForceMode);
    }
}
