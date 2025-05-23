namespace Db.WordCounter.Domain.Dtos.Occurrences;

public class OccurrencesDto
{
    public int ExcludedWordsEncounteredCount { get; set; }
    public Dictionary<string, int> WordCountModel { get; set; } = new Dictionary<string, int>();
}