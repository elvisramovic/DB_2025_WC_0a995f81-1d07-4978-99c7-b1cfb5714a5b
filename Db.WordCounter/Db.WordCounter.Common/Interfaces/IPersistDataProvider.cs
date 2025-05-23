using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Common.Interfaces;

public interface IPersistDataProvider
{
    public void SaveResultToFileAsJson(OccurrencesDto occurrencesDto);

    public void SaveResultToAlphabetOrderOccurrencesFile(OccurrencesDto occurrencesDto);
}
