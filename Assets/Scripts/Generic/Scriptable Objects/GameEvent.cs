using System;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    public event Action OnEvent;

    public void Execute() =>
        OnEvent?.Invoke();
}
