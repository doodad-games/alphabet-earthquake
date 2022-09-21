using UnityEngine;

public static class ApplicationSettings
{
    public static bool Quitting { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    public static void Init()
    {
        Quitting = false;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        Application.quitting +=
            () => Quitting = true;
    }
}
