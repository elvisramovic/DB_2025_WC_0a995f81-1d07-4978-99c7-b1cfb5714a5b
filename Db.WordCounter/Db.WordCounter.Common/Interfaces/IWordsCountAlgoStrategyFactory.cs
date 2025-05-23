using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Common.Interfaces;

public interface IWordsCountAlgoStrategyFactory
{
    IWordCounterStrategy CreateInstance(CountWordsAlgoType algoType);
}
