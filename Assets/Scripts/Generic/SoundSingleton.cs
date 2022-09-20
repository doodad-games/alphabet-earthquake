using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

// See Editor/Tests/Test_SoundSingleton

[AddComponentMenu("")]
[DefaultExecutionOrder(ExecOrder)]
public class SoundSingleton : SingletonBehaviour<SoundSingleton>
{
    // Early such to beat regular components that may try to play sounds on hot reload
    // (because we need sounds to re-register before something tries to play them).
    public const int ExecOrder = -100;

    /**
     * ## Example Matches
     *
     * - Nice 5 Sound
     * - Nice 5 Sound (2)(Clone)
     * - Nice 5 Sound.3(Clone)
     * - Nice 5 Sound_4
     * - Nice 5 Sound-5
     * - Nice 5 Sound 6
     *
     * In all of these cases, the first capture group will contain "Nice 5 Sound"
     *
     * ## Breakdown
     *
     *         ^(.+ )                                                  - first capture group represents the original object name
     *             ?                                                       - non-greedy so it won't capture the entire string
     *               (                            )?                   - optionally followed by a suffix for the count (e.g. " (2)", "_3", etc)
     *                [-._ ]?                                              - optional separator between name and suffix ("-", ".", "_" or " ")
     *                       (            |      )                         - check for two different formats
     *                        \\(      \\)                                 - literal parentheses (e.g. in "(12)")
     *                           [0-9]+    [0-9]+                          - one or more numbers, either standalone or inside the parentheses
     *                                              (\\(Clone\\))?$    - optionally ends with literal "(Clone)"
     */
    static readonly Regex _namePattern
        = new("^(.+?)([-._ ]?(\\([0-9]+\\)|[0-9]+))?(\\(Clone\\))?$");

    public static string GetName(AudioSource source) =>
        GetStrippedName(source.gameObject.name);
    public static string GetStrippedName(string gameObjectName)
    {
        var matches = _namePattern.Match(gameObjectName);
        BurstAssert.IsTrue(matches.Success);
        return matches.Groups[1].Value;
    }


    Dictionary<string, List<AudioSource>> _soundsByName = new();
    Dictionary<AudioSource, string> _namesBySound = new();

    public void RegisterSound(AudioSource source)
    {
        var name = GetName(source);

        if (!_soundsByName.ContainsKey(name))
            _soundsByName[name] = new List<AudioSource>();
        _namesBySound[source] = name;

        _soundsByName[name].Add(source);
    }

    public void DeregisterSound(AudioSource source)
    {
        var name = _namesBySound[source];

        _soundsByName[name].Remove(source);
        if (_soundsByName[name].Count == 0)
            _soundsByName.Remove(name);

        _namesBySound.Remove(source);
    }

    public AudioSource Get(string name) =>
        _soundsByName[name].PickRandom();

    public void Play(string name) =>
        Get(name).Play();

    public void PlayAtLocation(string name, Vector3 location)
    {
        var sound = Get(name);

        var clone = Instantiate(sound.gameObject, location, Quaternion.identity);
        clone.GetComponent<AudioSource>().Play();

        StartCoroutine(DestroyAfter(clone, sound.clip.length));
    }

    IEnumerator DestroyAfter(GameObject gameObject, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Destroy(gameObject);
    }
}

public static class Sound
{
    public static void RegisterSound(AudioSource source) =>
        SoundSingleton.I.RegisterSound(source);
    public static void Deregister(AudioSource source) =>
        SoundSingleton.I.DeregisterSound(source);
    public static AudioSource Get(string name) =>
        SoundSingleton.I.Get(name);
    public static void Play(string name) =>
        SoundSingleton.I.Play(name);
    public static void PlayAtLocation(string name, Vector3 location) =>
        SoundSingleton.I.PlayAtLocation(name, location);
}
