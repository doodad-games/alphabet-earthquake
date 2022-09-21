using System.Collections.Generic;
using UnityEngine;

public class PhoneticObjectChooser : MonoBehaviour
{
    public PhoneticObject[] Options;
    public UnityEventChar KeyboardCharacterCallbacks;
    public UnityEventString PhoneticDisplayCharactersCallbacks;
    public UnityEventString SoundNameCallbacks;
    public UnityEventGameObject PrefabCallbacks;

    List<PhoneticObject> _alreadyChosen = new();
    HashSet<PhoneticObject> _alreadyChosenSet = new();
    HashSet<PhoneticObject> _choicesRemaining = new();

    public void OnEnable()
    {
        _alreadyChosenSet.UnionWith(_alreadyChosen);

        _choicesRemaining.Clear();
        _choicesRemaining.UnionWith(Options);
        _choicesRemaining.ExceptWith(_alreadyChosenSet);
    }

    public void CB_Choose()
    {
        var choicesList = new List<PhoneticObject>(_choicesRemaining);
        var choice = choicesList.PickRandom();

        _alreadyChosen.Add(choice);
        _alreadyChosenSet.Add(choice);
        _choicesRemaining.Remove(choice);

        var prefab = Resources.Load<GameObject>(choice.PrefabName);

        KeyboardCharacterCallbacks?.Invoke(choice.KeyboardCharacter);
        PhoneticDisplayCharactersCallbacks?.Invoke(choice.PhoneticDisplayCharacters);
        SoundNameCallbacks?.Invoke(choice.SoundName);
        PrefabCallbacks?.Invoke(prefab);
    }
}
