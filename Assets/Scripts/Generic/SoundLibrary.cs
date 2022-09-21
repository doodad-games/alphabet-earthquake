using UnityEngine;

/**
 * ## Notes
 *
 * ### Audio source layout
 * Each audio source should exist on a separate game object that is a child or ancestor of this one,
 * e.g. not on the same game object as this one and not on the same game object as any other audio source,
 * because SoundSingleton.PlayAtLocation needs to clone audio source game objects.
 *
 * ### No reaction to changes in children
 * Changes to child audio sources or game objects are ignored, including if they're enabled or disabled.
 * You can manually refresh things by disabling and re-enabling the sound library itself.
 */

public class SoundLibrary : MonoBehaviour
{
    AudioSource[] _sounds;

    public void OnEnable()
    {
        _sounds = GetComponentsInChildren<AudioSource>();
        foreach (var sound in _sounds)
            Sound.Register(sound);
    }

    public void OnDisable()
    {
        if (SoundSingleton.I != null)
            foreach (var sound in _sounds)
                Sound.Deregister(sound);
    }
}
