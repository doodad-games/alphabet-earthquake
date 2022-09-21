using UnityEngine;

public class SoundCallbacks : MonoBehaviour
{
    public void CB_PlaySound(string name) =>
        Sound.Play(name);
}
