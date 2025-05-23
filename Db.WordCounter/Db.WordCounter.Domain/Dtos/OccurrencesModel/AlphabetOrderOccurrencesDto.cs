namespace Db.WordCounter.Domain.Dtos.Occurrences;

public class AlphabetOrderOccurrencesDto
{
    public SortedList<string, List<AlphabetOrderOccurrencesDetailDto>> AlphabetOrderOccurrencesModel { get; set; } = new SortedList<string, List<AlphabetOrderOccurrencesDetailDto>>();
}
