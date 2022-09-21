using UnityEngine;

public class SoundCallbacks : MonoBehaviour
{
    public void CB_Play(string name) =>
        Sound.Play(name);
}
