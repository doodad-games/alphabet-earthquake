using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DoCallbacksOnKeyPress : MonoBehaviour
{
    public Key Key;
    public UnityEvent Callbacks;

    public void Update()
    {
        if (Key == Key.None || Key == Key.IMESelected)
            return;

        if (Keyboard.current.allKeys[(int)Key - 1].wasPressedThisFrame)
            Callbacks?.Invoke();
    }

    // I know, this is slow 😅
    public void CB_UseKey(char key)
    {
        var lowerCaseKey = Char.ToLower(key);
        foreach (var keyOption in Keyboard.current.allKeys)
            if (
                keyOption.displayName.Length == 1 &&
                lowerCaseKey == keyOption.displayName.ToLower()[0]
            ) Key = keyOption.keyCode;
    }

    public void CB_ClearKey() =>
        Key = Key.None;
}
