using AutoFixture;
using Db.WordCounter.Application.Facade;
using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;
using Moq;

namespace Db.WordCounter.Application.Tests.Facade;

[TestClass]
public class AlphabetOccurrencesFacadeTests
{
    private readonly Mock<IPersistDataProvider> _persistDataProvider;

    public AlphabetOccurrencesFacadeTests()
    {
        _persistDataProvider = new Mock<IPersistDataProvider>();
    }

    [TestMethod]

    public void VerifyIsCallSaveResultToFileAsJsonOnce()
    {
        // Arrange
        var fixtureOccurrencesDto = new Fixture().Create<OccurrencesDto>();

        _persistDataProvider.Setup(x => x.SaveResultToFileAsJson(It.IsAny<OccurrencesDto>()));
        var sut = new AlphabetOccurrencesFacade(_persistDataProvider.Object);

        // Act
        sut.PersistOccurrences(fixtureOccurrencesDto);

        // Assert
        _persistDataProvider.Verify(e => e.SaveResultToFileAsJson(fixtureOccurrencesDto), Times.Once);
    }

    [TestMethod]

    public void VerifyIsCallSaveResultToAlphabetOrderOccurrencesFileOnce()
    {
        // Arrange
        var fixtureOccurrencesDto = new Fixture().Create<OccurrencesDto>();

        _persistDataProvider.Setup(x => x.SaveResultToAlphabetOrderOccurrencesFile(It.IsAny<OccurrencesDto>()));
        var sut = new AlphabetOccurrencesFacade(_persistDataProvider.Object);

        // Act
        sut.PersistAlphabetOrderOccurrences(fixtureOccurrencesDto);

        // Assert
        _persistDataProvider.Verify(e => e.SaveResultToAlphabetOrderOccurrencesFile(fixtureOccurrencesDto), Times.Once);
    }
}
