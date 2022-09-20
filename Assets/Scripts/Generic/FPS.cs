using UnityEngine;

public class FPS : MonoBehaviour
{
    public int FrameRange = 60;
    public UnityEventInt OnUpdate;

    int[] _fpsBuffer = new int[0];
    int _nextFrameIndex;
    int _averageFPS;

    public void Update()
    {
        MaybeResizeFPSBuffer();
        RecordCurrentFPS();
        CalculateFPS();
        OnUpdate?.Invoke(AverageFPS);
    }

    public int AverageFPS => _averageFPS;

    void MaybeResizeFPSBuffer()
    {
        if (FrameRange <= 0)
            FrameRange = 1;

        if (_fpsBuffer.Length != FrameRange)
        {
            _fpsBuffer = new int[FrameRange];
            _nextFrameIndex = 0;
        }
    }

    void RecordCurrentFPS()
    {
        _fpsBuffer[_nextFrameIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (_nextFrameIndex >= FrameRange)
            _nextFrameIndex = 0;
    }

    void CalculateFPS()
    {
        var sum = 0;
        foreach (var fps in _fpsBuffer)
            sum += fps;
        _averageFPS = (int)(sum / FrameRange);
    }
}
