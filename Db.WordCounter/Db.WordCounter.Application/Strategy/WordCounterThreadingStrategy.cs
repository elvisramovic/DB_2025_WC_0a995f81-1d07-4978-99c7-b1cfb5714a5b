using System.Collections.Concurrent;
using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Strategy;

public class WordCounterThreadingStrategy : WordCounterBase, IWordCounterStrategy
{
    private readonly ConcurrentDictionary<string, int> countModelConcurrentDictionary = new ConcurrentDictionary<string, int>();

    public WordCounterThreadingStrategy() : base(CountWordsAlgoType.Parallel)
    {
    }

    public Dictionary<string, int> GetWordCountModel()
    {
        return new Dictionary<string, int>(countModelConcurrentDictionary);
    }

    public void CountWords(IEnumerable<string> inputs)
    {
        var options = new ParallelOptions { MaxDegreeOfParallelism = 8 };

        Parallel.ForEach(inputs, options, SplitToWord);
    }

    private void SplitToWord(string input)
    {
        var wordsWithSpecialChar = input.Split(' ');

        foreach (var key in wordsWithSpecialChar)
        {
            countModelConcurrentDictionary.AddOrUpdate(key, 1, (key, oldValue) => oldValue + 1);
        }
    }
}