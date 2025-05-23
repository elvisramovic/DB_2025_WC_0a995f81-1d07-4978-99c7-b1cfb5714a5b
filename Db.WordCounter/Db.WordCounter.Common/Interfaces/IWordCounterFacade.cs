using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Common.Interfaces;

public interface IWordCounterFacade
{
    OccurrencesDto CountWords(CountWordsAlgoType algoType);
}
