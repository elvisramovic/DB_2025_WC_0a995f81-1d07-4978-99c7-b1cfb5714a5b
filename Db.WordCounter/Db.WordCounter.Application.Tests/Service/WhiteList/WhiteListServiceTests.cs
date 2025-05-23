using AutoFixture;
using Db.WordCounter.Application.Service.WhiteList;
using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Tests.Service.WhiteList;

[TestClass]
public class WhiteListServiceTests
{
    [TestMethod]

    public void VerifyWhiteList()
    {
        // Arrange
        var whiteList = new HashSet<string>()
        {
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>(),
            new Fixture().Create<string>()
        };

        var fixtureOccurrencesDto = new OccurrencesDto();

        // Act
        foreach (var key in whiteList) 
        {
            if (!fixtureOccurrencesDto.WordCountModel.ContainsKey(key))
            {
                fixtureOccurrencesDto.WordCountModel.Add(key, 3);
            }
        }

        foreach (var w in whiteList)
        {
            Assert.IsTrue(fixtureOccurrencesDto.WordCountModel.ContainsKey(w));
        }

        var sut = new WhiteListService(fixtureOccurrencesDto.WordCountModel.Keys);

        var actual = sut.Exclude(fixtureOccurrencesDto);

        // Assert
        foreach (var w in whiteList)
        {
            Assert.IsFalse(actual.WordCountModel.ContainsKey(w));
        }

        Assert.AreEqual(actual.ExcludedWordsEncounteredCount, 10 * 3);
    }
}
