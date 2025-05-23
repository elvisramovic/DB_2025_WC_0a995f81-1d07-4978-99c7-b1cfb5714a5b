using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Facade;

public class AlphabetOccurrencesFacade : IAlphabetOccurrencesFacade
{
    private readonly IPersistDataProvider _persistDataProvider;

    public AlphabetOccurrencesFacade(IPersistDataProvider persistDataProvider)
    {
        _persistDataProvider = persistDataProvider;
    }

    public void PersistAlphabetOrderOccurrences(OccurrencesDto occurrencesDto)
    {
        _persistDataProvider.SaveResultToAlphabetOrderOccurrencesFile(occurrencesDto);
    }

    public void PersistOccurrences(OccurrencesDto occurrencesDto)
    {
        _persistDataProvider.SaveResultToFileAsJson(occurrencesDto);
    }
}
