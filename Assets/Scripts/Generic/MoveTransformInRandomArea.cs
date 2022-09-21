using UnityEngine;

public class MoveTransformInRandomArea : MonoBehaviour
{
    public Transform TransformToMove;
    [Tooltip("Assumed to have no rotation applied.")]
    public BoxCollider Area;

    public void CB_Execute() =>
        TransformToMove.position = new Vector3(
            Random.Range(Area.bounds.min.x, Area.bounds.max.x),
            Random.Range(Area.bounds.min.y, Area.bounds.max.y),
            Random.Range(Area.bounds.min.z, Area.bounds.max.z)
        );
}
