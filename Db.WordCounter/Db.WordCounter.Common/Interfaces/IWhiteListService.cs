using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Common.Interfaces;

public interface IWhiteListService
{
    OccurrencesDto Exclude(OccurrencesDto occurrencesDto);
}
