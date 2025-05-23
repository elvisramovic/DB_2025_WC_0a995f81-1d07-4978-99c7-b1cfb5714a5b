using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Common.Interfaces;

public interface IFilePersistData
{
    void SaveResultToFile(OccurrencesDto occurrencesDto);
    void SaveResultToAlphabetOrderOccurrencesFile(AlphabetOrderOccurrencesDto alphabetOrderOccurrencesDto);
}