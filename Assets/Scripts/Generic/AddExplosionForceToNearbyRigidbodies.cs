using UnityEngine;

public class AddExplosionForceToNearbyRigidbodies : MonoBehaviour
{
    [field: SerializeField] public bool ActivateOnEnable { get; set; }
    [field: SerializeField] public float ExplosionForce { get; set; }
    [field: SerializeField] public float ExplosionRadius { get; set; }
    [field: SerializeField] public float UpwardsModifier { get; set; }

    public void OnEnable()
    {
        if (ActivateOnEnable)
            CB_AddExplosionForceToNearbyRigidbodies();
    }

    public void CB_AddExplosionForceToNearbyRigidbodies()
    {
        if (ExplosionRadius == 0)
            return;

        var explosionPos = transform.position;
        var colliders = Physics.OverlapSphere(explosionPos, ExplosionRadius);
        foreach (var collider in colliders)
            collider.attachedRigidbody
                ?.AddExplosionForce(
                    ExplosionForce,
                    transform.position,
                    ExplosionRadius,
                    UpwardsModifier
                );
    }
}
