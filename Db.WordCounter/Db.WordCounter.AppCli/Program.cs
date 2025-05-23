using Db.WordCounter.AppCli.Service;

namespace Db.WordCounter.AppCli;

internal class Program
{
    static string defaultdirectoryPath = ".\\ReadData\\SystemIoModel\\Io\\RowData\\Input\\";

    static void Main(string[] args)
    {
        Console.WriteLine("WordCounter start!");
        Console.WriteLine();

        var directoryPath = LoadInputDataIfAny(args);


        Console.WriteLine("Read data from multiple files in a directory on disk & Count the number of occurrences for each word from all files");
        var occurrencesDtoSynchronyStrategy = WordCounterCliService.CountWordsSynchronyStrategy(directoryPath);
        var occurrencesDtoParallelStrategy = WordCounterCliService.CountWordsSynchronyParallel(directoryPath);
        Console.WriteLine();


        Console.WriteLine("Exclude any words from a list that is in exclude.txt file & Count the number of excluded words encountered");
        var occurrencesDtoSynchronyStrategyAndExcludeRule = WordCounterCliService.RunExcludedWhiteListService(occurrencesDtoSynchronyStrategy);
        Console.WriteLine($"ExcludedWordsEncounteredCount is =  {occurrencesDtoSynchronyStrategyAndExcludeRule.ExcludedWordsEncounteredCount}");

        var delta10 = occurrencesDtoSynchronyStrategy.WordCountModel.Count - occurrencesDtoSynchronyStrategyAndExcludeRule.WordCountModel.Count;
        Console.WriteLine($"Delta is =  {delta10}");
        Console.WriteLine();

        Console.WriteLine("Create a file on disk for each letter in the alphabet and write the words and their count of occurrencesto them.");
        WordCounterCliService.RunAlphabetOccurrencesService(occurrencesDtoSynchronyStrategyAndExcludeRule);
        Console.WriteLine();

        Console.WriteLine("WordCounter end!");
    }

    private static string LoadInputDataIfAny(string[] args)
    {
        var directoryPath = string.Empty;

        if (args.Any())
        {
            directoryPath = args?.FirstOrDefault() ?? defaultdirectoryPath;
        }
        else
        {
            directoryPath = defaultdirectoryPath;
        }

        return directoryPath;
    }
}
