using UnityEngine;

public class ExplosionForceApplier : MonoBehaviour
{
    [field: SerializeField] public bool ExplodeOnEnable { get; set; }
    [field: SerializeField] public float ExplosionForce { get; set; }
    [field: SerializeField] public float ExplosionRadius { get; set; }
    [field: SerializeField] public float UpwardsModifier { get; set; }

    public void OnEnable()
    {
        if (ExplodeOnEnable)
            CB_ApplyExplosionForceToAllRigidbodies();
    }

    public void CB_ApplyExplosionForceToAllRigidbodies()
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
