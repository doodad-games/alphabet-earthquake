using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public Vector3 TargetScale = Vector3.one;
    public float Duration = 0.5f;

    public void Awake() =>
        transform.localScale = Vector3.zero;

    public void Start() =>
        new Async(this)
            .Lerp(
                0, 1, Duration,
                step => transform.localScale = TargetScale * step
            )
            .Then(
                () => Destroy(this)
            );
}
