using UnityEngine;

public class DoCallbacksOnCollision : MonoBehaviour
{
    public float Cooldown;
    public float ImpulseThreshold;
    public bool AlsoCheckOtherColliderForCooldown;

    float _cooldownRemaining;

    [Space(10)]
    public UnityEventVector3 Callbacks;

    public void Update()
    {
        if (_cooldownRemaining != 0f)
        {
            if (_cooldownRemaining <= Time.deltaTime)
                _cooldownRemaining = 0f;
            else _cooldownRemaining -= Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (
            _cooldownRemaining != 0f ||
            collision.impulse.magnitude < ImpulseThreshold
        ) return;

        DoCallbacksOnCollision otherComp = null;

        if (AlsoCheckOtherColliderForCooldown)
        {
            otherComp = collision.collider.GetComponentInParent<DoCallbacksOnCollision>();
            if (
                otherComp != null &&
                otherComp._cooldownRemaining != 0f
            ) return;
        }

        _cooldownRemaining = Cooldown;

        if (otherComp != null)
            otherComp._cooldownRemaining = otherComp.Cooldown;

        Callbacks?.Invoke(collision.contacts[0].point);
    }
}
