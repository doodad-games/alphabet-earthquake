using UnityEngine;

public class AnimatorCallbacks : MonoBehaviour
{
    public Animator Animator;
    public string PropertyName;

    public void CB_SetBool(bool value) =>
        Animator.SetBool(PropertyName, value);
}
