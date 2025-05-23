using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Common.Interfaces;

public interface IAlphabetOccurrencesFacade
{
    void PersistOccurrences(OccurrencesDto occurrencesDto);

    void PersistAlphabetOrderOccurrences(OccurrencesDto occurrencesDto);
}