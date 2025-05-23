using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Service.WhiteList;

public class WhiteListService : IWhiteListService
{
    private readonly ISet<string> _excludeWhiteListModel;

    public WhiteListService(Dictionary<string, int>.KeyCollection keys)
    {
        _excludeWhiteListModel = new HashSet<string>(keys);
    }

    public OccurrencesDto Exclude(OccurrencesDto occurrencesDto)
    {
        var immutableOccurrencesDto = new OccurrencesDto
        {
            WordCountModel = new Dictionary<string, int>(occurrencesDto.WordCountModel)
        };


        foreach (var workToExclude in _excludeWhiteListModel)
        {
            if (immutableOccurrencesDto.WordCountModel.ContainsKey(workToExclude))
            {
                immutableOccurrencesDto.ExcludedWordsEncounteredCount += occurrencesDto.WordCountModel[workToExclude];
                immutableOccurrencesDto.WordCountModel.Remove(workToExclude);
            }
        }

        return immutableOccurrencesDto;
    }
}
