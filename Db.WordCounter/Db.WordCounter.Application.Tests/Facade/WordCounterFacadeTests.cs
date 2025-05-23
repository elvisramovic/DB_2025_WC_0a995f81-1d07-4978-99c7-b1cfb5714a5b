using Db.WordCounter.Application.Facade;
using Db.WordCounter.Application.Strategy;
using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;
using Moq;

namespace Db.WordCounter.Application.Tests.Facade;

[TestClass]
public class WordCounterFacadeTests
{
    private readonly Mock<IWordsCountAlgoStrategyFactory> _wordsCountAlgoStrategyFactory;
    private readonly Mock<IWordCounterDataProvider> _wordCounterDataProvider;

    public WordCounterFacadeTests()
    {
        _wordsCountAlgoStrategyFactory = new Mock<IWordsCountAlgoStrategyFactory>();
        _wordCounterDataProvider = new Mock<IWordCounterDataProvider>();
    }

    [TestMethod]

    public void VerifyCall_CreateInstance_Once()
    {
        // Arrange
        var fixture = CountWordsAlgoType.Synchrony;

        _wordsCountAlgoStrategyFactory.Setup(x => x.CreateInstance(It.IsAny<CountWordsAlgoType>())).Returns(new WordCounterSynchronyStrategy());

        var sut = new WordCounterFacade(_wordsCountAlgoStrategyFactory.Object, _wordCounterDataProvider.Object);

        // Act
        var actual = sut.CountWords(fixture);

        // Assert
        _wordsCountAlgoStrategyFactory.Verify(e => e.CreateInstance(fixture), Times.Once);
    }
}