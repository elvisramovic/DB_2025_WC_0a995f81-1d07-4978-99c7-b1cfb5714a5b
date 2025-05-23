using AutoFixture;
using Db.WordCounter.Application.Facade;
using Db.WordCounter.Application.Strategy;
using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;
using Db.WordCounter.Infrastructure.ReadData.SystemIoModel.Provider;
using Moq;
using System.Diagnostics;

namespace Db.WordCounter.Application.Tests.Strategy;

[TestClass]
public class PerformanceAlgorithmsStrategyCheck_NotUnitTest
{
    private readonly Mock<IWordCounterFileHelper> _wordCounterFileHelper;
    private readonly Mock<IWordsCountAlgoStrategyFactory> _wordsCountAlgoStrategyFactory;

    public PerformanceAlgorithmsStrategyCheck_NotUnitTest()
    {
        _wordCounterFileHelper = new Mock<IWordCounterFileHelper>();
        _wordsCountAlgoStrategyFactory = new Mock<IWordsCountAlgoStrategyFactory>();

    }

    [TestMethod]
    [DataRow(12)]
    public void WordCounterSynchronyStrategy(int addRange)
    {
        var fixtureStockDataModel = new Fixture().Create<IEnumerable<string>>();

        var fileList = new List<string>
        {
            ".\\Strategy\\Performance\\Files\\TextFile_900.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_901.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_902.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_903.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_904.txt"
        };

        for (int i = 0; i < addRange; i++)
            fileList.AddRange(fileList);

        _wordCounterFileHelper.Setup(x => x.GetPathToFiles(It.IsAny<string>())).Returns(fileList);
        _wordCounterFileHelper.Setup(x => x.ReadAllLines(It.IsAny<string>())).Returns(ReadAllLinesFake(".\\Strategy\\Performance\\Files\\TextFile_900.txt"));

        _wordsCountAlgoStrategyFactory.Setup(x => x.CreateInstance(It.IsAny<CountWordsAlgoType>())).Returns(new WordCounterSynchronyStrategy());

        Console.WriteLine($"Demo Time!");
        var sw = new Stopwatch();

        sw.Start();

        var fileWordCounterDataProvider = new FileWordCounterDataProvider(_wordCounterFileHelper.Object, It.IsAny<string>());

        var sut = new WordCounterFacade(_wordsCountAlgoStrategyFactory.Object, fileWordCounterDataProvider);

        var res = sut.CountWords(CountWordsAlgoType.Synchrony);

        sw.Stop();
        Console.WriteLine($"Elapsed:= {sw.Elapsed}");
        sw.Reset();
    }

    /*
         Elapsed:= 00:00:37.7402098
     */


    [TestMethod]
    [DataRow(12)]
    public void WordCounterThreadingStrategy(int addRange)
    {
        var fixtureStockDataModel = new Fixture().Create<IEnumerable<string>>();

        var fileList = new List<string>
        {
            ".\\Strategy\\Performance\\Files\\TextFile_900.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_901.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_902.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_903.txt",
            ".\\Strategy\\Performance\\Files\\TextFile_904.txt"
        };

        for (int i = 0; i < addRange; i++)
            fileList.AddRange(fileList);


        _wordCounterFileHelper.Setup(x => x.GetPathToFiles(It.IsAny<string>())).Returns(fileList);
        _wordCounterFileHelper.Setup(x => x.ReadAllLines(It.IsAny<string>())).Returns(ReadAllLinesFake(".\\Strategy\\Performance\\Files\\TextFile_900.txt"));

        _wordsCountAlgoStrategyFactory.Setup(x => x.CreateInstance(It.IsAny<CountWordsAlgoType>())).Returns(new WordCounterThreadingStrategy());

        Console.WriteLine($"Demo Time!");
        var sw = new Stopwatch();

        sw.Start();

        var fileWordCounterDataProvider = new FileWordCounterDataProvider(_wordCounterFileHelper.Object, It.IsAny<string>());

        var sut = new WordCounterFacade(_wordsCountAlgoStrategyFactory.Object, fileWordCounterDataProvider);

        var res = sut.CountWords(CountWordsAlgoType.Synchrony);


        sw.Stop();
        Console.WriteLine($"Elapsed:= {sw.Elapsed}");
        sw.Reset();
    }

    /*
    Elapsed:= 00:00:20.5391312
    */

    private IEnumerable<string> ReadAllLinesFake(string filePath)
    {
        var allLines = File.ReadAllLines(filePath);

        return allLines;
    }
}
