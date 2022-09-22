using UnityEngine;

/**
 * ## Notes
 *
 * The name of the scriptable object is used to match the name of the prefab in Resources, and the sound.
 */

[CreateAssetMenu(fileName = "Phonetic Object", menuName = "Game/Phonetic Object")]
public class PhoneticObject : ScriptableObject
{
    const string SoundNameTemplate = "Phonetic Object_{0}";


    /// <summary>e.g. "P" for "Pilot", "Sh" for "shell".</summary>
    public string PhoneticDisplayCharacters;
    public char KeyboardCharacter;

    public string PrefabName => name;
    public string SoundName => string.Format(SoundNameTemplate, name);
}
