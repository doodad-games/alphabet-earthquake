using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Async
{
    MonoBehaviour _owner;
    bool _inStep;
    List<Func<IEnumerator>> _steps = new();

    public Async(MonoBehaviour owner) =>
        _owner = owner;
    public Async() : this(AsyncHelper.I) { }

    void MaybeTakeStep()
    {
        if (_steps.Count == 0 || _inStep)
            return;
        _inStep = true;

        var enumerator = _steps[0]();
        if (enumerator != null)
            _owner.StartCoroutine(enumerator);

        _steps.RemoveAt(0);

        if (enumerator == null)
            FinishedStep();
    }

    void FinishedStep()
    {
        _inStep = false;
        MaybeTakeStep();
    }

    // ## Coroutines

    // #### Then

    public Async Then(Action cb)
    {
        _steps.Add(() => {
            cb?.Invoke();
            return null;
        });
        MaybeTakeStep();
        return this;
    }


    // #### Lerp

    public Async Lerp(
        float from,
        float to,
        float over,
        Action<float> step,
        TimeType timeMode = TimeType.Scaled
    )
    {
        _steps.Add(
            () => LerpCoroutine(from, to, over, step, timeMode)
        );
        MaybeTakeStep();
        return this;
    }
    public Async Lerp(
        float over,
        Action<float> step,
        TimeType timeMode = TimeType.Scaled
    ) => Lerp(0, 1, over, step, timeMode);

    IEnumerator LerpCoroutine(
        float from,
        float to,
        float over,
        Action<float> cb,
        TimeType timeMode
    )
    {
        var cumulative = 0f;
        var change = to - from;

        while (cumulative < over)
        {
            var delta = timeMode == TimeType.Scaled
                ? Time.deltaTime
                : Time.unscaledDeltaTime;
            cumulative = Mathf.Min(cumulative + delta, over);
            var val = from + change * (cumulative / over);
            cb?.Invoke(val);

            yield return null;
        }

        cb?.Invoke(to);
        FinishedStep();
    }


    // #### Wait

    public Async Wait(float secs, TimeType timeMode = TimeType.Scaled)
    {
        _steps.Add(
            () => WaitCoroutine(secs, timeMode)
        );
        MaybeTakeStep();
        return this;
    }

    IEnumerator WaitCoroutine(float secs, TimeType timeMode)
    {
        if (timeMode == TimeType.Scaled)
            yield return new WaitForSeconds(secs);
        else yield return new WaitForSecondsRealtime(secs);
        FinishedStep();
    }


    // #### Next

    public Async Next(int frames = 1)
    {
        _steps.Add(
            () => NextCoroutine(frames)
        );
        MaybeTakeStep();
        return this;
    }

    IEnumerator NextCoroutine(int frames)
    {
        while (frames != 0)
        {
            yield return new WaitForEndOfFrame();
            --frames;
        }
        FinishedStep();
    }


    // #### Every

    public Async Every(float secs, Action cb)
    {
        _steps.Add(
            () => EveryCoroutine(secs, cb)
        );
        MaybeTakeStep();
        return this;
    }

    IEnumerator EveryCoroutine(float secs, Action cb)
    {
        while (true)
        {
            yield return new WaitForSeconds(secs);
            cb?.Invoke();
        }
    }


    // #### LoadScene

    public Async LoadScene(string path)
    {
        _steps.Add(
            () => LoadSceneCoroutine(path)
        );
        MaybeTakeStep();
        return this;
    }

    IEnumerator LoadSceneCoroutine(string path)
    {
        var op = SceneManager.LoadSceneAsync(path);
        while(!op.isDone)
            yield return null;

        FinishedStep();
    }
}

[AddComponentMenu("")]
/// <summary>Exists to be the default host for coroutines started from the Async class.</summary>
internal class AsyncHelper : SingletonBehaviour<AsyncHelper> { }
