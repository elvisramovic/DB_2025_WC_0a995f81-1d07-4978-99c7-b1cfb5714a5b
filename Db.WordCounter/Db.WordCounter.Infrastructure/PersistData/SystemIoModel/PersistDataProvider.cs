using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;
using Db.WordCounter.Infrastructure.PersistData.SystemIoModel.Adapter;

namespace Db.WordCounter.Infrastructure.PersistData;

public class PersistDataProvider : IPersistDataProvider
{
    private readonly IFilePersistData _filePersistData;

    public PersistDataProvider(IFilePersistData filePersistData)
    {
        _filePersistData = filePersistData;
    }

    public void SaveResultToAlphabetOrderOccurrencesFile(OccurrencesDto occurrencesDto)
    {
        var alphabetOrderOccurrencesHelper = new AlphabetOrderOccurrencesAdapter();

        _filePersistData.SaveResultToAlphabetOrderOccurrencesFile(alphabetOrderOccurrencesHelper.TransformModel(occurrencesDto));
    }

    public void SaveResultToFileAsJson(OccurrencesDto occurrencesDto)
    {
        _filePersistData.SaveResultToFile(occurrencesDto);
    }
}
