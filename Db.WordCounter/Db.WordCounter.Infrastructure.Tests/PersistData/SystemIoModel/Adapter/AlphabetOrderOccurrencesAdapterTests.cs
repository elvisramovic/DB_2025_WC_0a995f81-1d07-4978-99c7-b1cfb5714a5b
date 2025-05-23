using AutoFixture;
using Db.WordCounter.Domain.Dtos.Occurrences;
using Db.WordCounter.Infrastructure.PersistData.SystemIoModel.Adapter;
using Moq;

namespace Db.WordCounter.Infrastructure.Tests.PersistData.SystemIoModel.Adapter;

[TestClass]
public class AlphabetOrderOccurrencesAdapterTests
{
    [TestMethod]
    [DataRow("A11", 5, "A12", 4, "A13", 11, "E13", 4, "A", 20, "E", 4)]
    [DataRow("k11", 5, "k12", 4, "k13", 1, "B13", 2, "K", 10, "B", 2)]

    public void VerifyAlphabetOrderOccurrencesModel(
        string word1, int expectedX1, 
        string word2, int expectedX2, 
        string word3, int expectedX3,
        string word4, int expectedX4,
        string leter1, int total1,
        string leter2, int total2)
    {
        // Arrange
        var fixtureOccurrencesDto = new OccurrencesDto
        {
            ExcludedWordsEncounteredCount = 10,
            WordCountModel = new Dictionary<string, int>
            {
                { word1, expectedX1 },
                { word2, expectedX2 },
                { word3, expectedX3 },
                { word4, expectedX4 }
            }
        };

        var sut = new AlphabetOrderOccurrencesAdapter();

        // Act
        var actual = sut.TransformModel(fixtureOccurrencesDto);

        // Assert
        var totalCount_1 = actual.AlphabetOrderOccurrencesModel[leter1].Sum(x => x.Count);
        var totalCount_2 = actual.AlphabetOrderOccurrencesModel[leter2].Sum(x => x.Count);

        Assert.AreEqual(total1, totalCount_1);
        Assert.AreEqual(total2, totalCount_2);
    }
}