namespace Db.WordCounter.Domain.Dtos.Occurrences;

public class AlphabetOrderOccurrencesDetailDto
{
    public string Word { get; set; }
    public int Count { get; set; }

    public override string ToString()
    {
        return $"{Word.ToUpper()} {Count}";
    }
}