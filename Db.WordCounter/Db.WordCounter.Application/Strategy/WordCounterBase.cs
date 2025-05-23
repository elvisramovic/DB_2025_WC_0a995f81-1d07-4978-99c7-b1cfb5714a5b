using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Strategy;

public class WordCounterBase
{
    public CountWordsAlgoType AlgoType { get; private set; }

    public WordCounterBase(CountWordsAlgoType algoType)
    {
        AlgoType = algoType;
    }

    public override string ToString()
    {
        return AlgoType.ToString();
    }
}
