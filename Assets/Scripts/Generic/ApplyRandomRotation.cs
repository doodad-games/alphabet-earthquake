using UnityEngine;

public class ApplyRandomRotation : MonoBehaviour
{
    public void Awake()
    {
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        Destroy(this);
    }
}
