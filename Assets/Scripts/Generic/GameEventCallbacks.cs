using UnityEngine;

public class GameEventCallbacks : MonoBehaviour
{
    public GameEvent Event;

    public void CB_DoGameEvent() =>
        Event.Execute();
}
