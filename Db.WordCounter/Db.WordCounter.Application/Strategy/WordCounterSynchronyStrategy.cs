using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Strategy;

public class WordCounterSynchronyStrategy : WordCounterBase, IWordCounterStrategy
{
    private readonly Dictionary<string, int> countModel = new Dictionary<string, int>();

    public WordCounterSynchronyStrategy() : base(CountWordsAlgoType.Synchrony)
    {
    }

    public Dictionary<string, int> GetWordCountModel()
    {
        return new Dictionary<string, int>(countModel);
    }

    public void CountWords(IEnumerable<string> inputs)
    {
        foreach (var fileLine in inputs)
        {
            SplitToWord(fileLine);
        }
    }

    private void SplitToWord(string fileLine)
    {
        var wordsWithSpecialChar = fileLine.Split(' ');

        foreach (var key in wordsWithSpecialChar)
        {
            if (countModel.ContainsKey(key))
            {
                countModel[key]++;
            }
            else
            {
                countModel.Add(key, 1);
            }
        }
    }
}

