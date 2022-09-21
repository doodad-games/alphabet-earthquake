using NUnit.Framework;

public class Test_SoundSingleton
{
    static readonly (string, string)[] _strippedNameTests = new[]
    {
        ("Nice 5 Sound", "Nice 5 Sound"),
        ("Nice 2 Sound 1", "Nice 2 Sound"),
        ("Nace 5 Sound (2)", "Nace 5 Sound"),
        ("Nice 5 Soond-(3)", "Nice 5 Soond"),
        ("Nace 2 Soond_4", "Nace 2 Soond"),
        ("Click.5", "Click"),
        ("Har har har-6", "Har har har"),
        ("Very exciting7", "Very exciting")
    };

    [Test]
    public void GetStrippedName(
        [ValueSource(nameof(_strippedNameTests))] (string, string) test
    )
    {
        var (input, expectedStrippedName) = test;
        Assert.AreEqual(
            expectedStrippedName,
            SoundSingleton.GetStrippedName(input)
        );
    }
}
