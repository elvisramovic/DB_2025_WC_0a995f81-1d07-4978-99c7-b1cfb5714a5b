using Db.WordCounter.Application.Strategy;
using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Factory;

public class AlgoStrategyFactory : IWordsCountAlgoStrategyFactory
{
    public IWordCounterStrategy CreateInstance(CountWordsAlgoType algoType)
    {
        return algoType switch
        {
            CountWordsAlgoType.Synchrony => new WordCounterSynchronyStrategy(),
            CountWordsAlgoType.Parallel => new WordCounterThreadingStrategy(),
            CountWordsAlgoType.Unknown => new WordCounterSynchronyStrategy(),
            _ => new WordCounterSynchronyStrategy(),
        };
    }
}
