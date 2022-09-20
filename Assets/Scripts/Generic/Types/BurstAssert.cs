#define USE_BURST_ASSERT

using System;

/// <summary>
/// Regular Unity.Assertions are compiled out in burst functions, even in the editor.
/// That's a little overkill at times, so these BurstAsserts can back you up.
/// </summary>
public static class BurstAssert
{
    public class AssertionException : Exception { }

    public static void Fail()
    {
#if USE_BURST_ASSERT
        throw new AssertionException();
#endif
    }

    public static void IsTrue(bool value)
    {
#if USE_BURST_ASSERT
        if (!value)
            throw new AssertionException();
#endif
    }

    public static void IsFalse(bool value)
    {
#if USE_BURST_ASSERT
        if (value)
            throw new AssertionException();
#endif
    }

    public static void IsNotNull<T>(T value)
    {
#if USE_BURST_ASSERT
        if (value == null)
            throw new AssertionException();
#endif
    }
}
