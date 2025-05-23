using Db.WordCounter.Application.Strategy;

namespace Db.WordCounter.Application.Tests.Strategy;


[TestClass]
public class WordCounterSynchronyStrategyTests
{
    private readonly string x1 = "x1";
    private readonly string x2 = "x2";
    private readonly string x3 = "x3";
    private readonly string x4 = "x4";


    [TestMethod]
    [DataRow(new string[] { "x1 x2 x3 x4 x3", "x1 x2 x3 x4 x2 x1" }, 3, 3, 3, 2)]
    [DataRow(new string[] { "x1 x2 x3 x4 x3", "x1 x2 x3 x4 x2" }, 2, 3, 3, 2)]

    public void VerifyWordCount_For_WordCounterSynchronyStrategy(IEnumerable<string> input, int expectedX1, int expectedX2, int expectedX3, int expectedX4)
    {
        // Arrange        
        var sut = new WordCounterSynchronyStrategy();
        
        // Act
        sut.CountWords(input);

        var getWordCountModeActual = sut.GetWordCountModel();

        // Assert
        Assert.AreEqual(getWordCountModeActual[x1], expectedX1);
        Assert.AreEqual(getWordCountModeActual[x2], expectedX2);
        Assert.AreEqual(getWordCountModeActual[x3], expectedX3);
        Assert.AreEqual(getWordCountModeActual[x4], expectedX4);
    }

    [TestMethod]
    [DataRow(new string[] { "x1 x2 x3 x4 x3", "x1 x2 x3 x4 x2 x1" }, 3, 3, 3, 2)]
    [DataRow(new string[] { "x1 x2 x3 x4 x3", "x1 x2 x3 x4 x2" }, 2, 3, 3, 2)]

    public void VerifyWordCount_For_WordCounterThreadingStrategy(IEnumerable<string> input, int expectedX1, int expectedX2, int expectedX3, int expectedX4)
    {
        var sut = new WordCounterThreadingStrategy();

        sut.CountWords(input);

        var getWordCountModeActual = sut.GetWordCountModel();

        Assert.AreEqual(getWordCountModeActual[x1], expectedX1);
        Assert.AreEqual(getWordCountModeActual[x2], expectedX2);
        Assert.AreEqual(getWordCountModeActual[x3], expectedX3);
        Assert.AreEqual(getWordCountModeActual[x4], expectedX4);
    }
}
