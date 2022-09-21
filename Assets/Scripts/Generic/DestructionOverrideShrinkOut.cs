using UnityEngine;

public class DestructionOverrideShrinkOut : MonoBehaviour
{
    public float ShrinkTime = 0.5f;

    public void CB_DestroyWithOverride() =>
        new Async(this)
            .Lerp(
                1, 0, ShrinkTime,
                step => transform.localScale = Vector3.one * step
            )
            .Then(
                () => Destroy(gameObject)
            );
}
