namespace Db.WordCounter.Common.Interfaces;

public interface IWordCounterStrategy
{
    void CountWords(IEnumerable<string> inputs);
    Dictionary<string, int> GetWordCountModel();
}
