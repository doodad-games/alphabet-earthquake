using UnityEngine;

public class OverrideDestructionByScalingDown : MonoBehaviour
{
    public float Duration = 0.5f;

    public void CB_DestroyWithOverride() =>
        new Async(this)
            .Lerp(
                1, 0, Duration,
                step => transform.localScale = Vector3.one * step
            )
            .Then(
                () => Destroy(gameObject)
            );
}
