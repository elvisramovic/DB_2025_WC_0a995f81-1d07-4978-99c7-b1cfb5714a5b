using Db.WordCounter.Application.Facade;
using Db.WordCounter.Application.Factory;
using Db.WordCounter.Application.Service.WhiteList;
using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;
using Db.WordCounter.Infrastructure.PersistData;
using Db.WordCounter.Infrastructure.ReadData.SystemIoModel.Io;
using Db.WordCounter.Infrastructure.ReadData.SystemIoModel.Provider;
using System.Diagnostics;

namespace Db.WordCounter.AppCli.Service;

public static class WordCounterCliService
{
    public static OccurrencesDto CountWordsSynchronyStrategy(string directoryPath)
    {
        Console.WriteLine("CountWordsSynchronyStrategy start!");


        IWordsCountAlgoStrategyFactory algoStrategyFactory = new AlgoStrategyFactory();
        IWordCounterFileHelper wordCounterFileHelper = new WordCounterFileHelper();
        IWordCounterDataProvider wordCounterDataProvider = new FileWordCounterDataProvider(wordCounterFileHelper, directoryPath);

        var wordCounterFacade = new WordCounterFacade(algoStrategyFactory, wordCounterDataProvider);

        var sw = new Stopwatch();
        sw.Start();
        var resultOccurrencesDto = wordCounterFacade.CountWords(CountWordsAlgoType.Synchrony);
        sw.Stop();

        Console.WriteLine($"Elapsed Synchrony:= {sw.Elapsed}");
        sw.Reset();

        return resultOccurrencesDto;
    }

    public static OccurrencesDto CountWordsSynchronyParallel(string directoryPath)
    {
        Console.WriteLine("CountWordsSynchronyParallel start!");

        IWordsCountAlgoStrategyFactory algoStrategyFactory = new AlgoStrategyFactory();
        IWordCounterFileHelper wordCounterFileHelper = new WordCounterFileHelper();
        IWordCounterDataProvider wordCounterDataProvider = new FileWordCounterDataProvider(wordCounterFileHelper, directoryPath);

        var wordCounterFacade = new WordCounterFacade(algoStrategyFactory, wordCounterDataProvider);

        var sw = new Stopwatch();
        sw.Start();
        var resultOccurrencesDto = wordCounterFacade.CountWords(CountWordsAlgoType.Parallel);

        sw.Stop();

        Console.WriteLine($"Elapsed Parallel:= {sw.Elapsed}");
        sw.Reset();

        return resultOccurrencesDto;
    }

    public static OccurrencesDto RunExcludedWhiteListService(OccurrencesDto occurrencesDto)
    {
        Console.WriteLine("Run Excluded WhiteListService start!");

        var directoryExcludeWhiteListPath = ".\\ReadData\\SystemIoModel\\Io\\RowData\\WhiteList";

        var reuseCountModelToGetExcludedData = CountWordsSynchronyStrategy(directoryExcludeWhiteListPath);

        var whiteListServiceOccurrencesDto = new WhiteListService(reuseCountModelToGetExcludedData.WordCountModel.Keys);

        var newModelWithExcludeList = whiteListServiceOccurrencesDto.Exclude(occurrencesDto);

        return newModelWithExcludeList;
    }

    public static void RunAlphabetOccurrencesService(OccurrencesDto newModelWithExcludeList)
    {
        Console.WriteLine("Run AlphabetOccurrences start!");

        IFilePersistData filePersistData = new FilePersistData();
        IPersistDataProvider persistDataProvider = new PersistDataProvider(filePersistData);
        IAlphabetOccurrencesFacade alphabetOccurrencesFacade = new AlphabetOccurrencesFacade(persistDataProvider);

        alphabetOccurrencesFacade.PersistOccurrences(newModelWithExcludeList);
        alphabetOccurrencesFacade.PersistAlphabetOrderOccurrences(newModelWithExcludeList);
    }
}
