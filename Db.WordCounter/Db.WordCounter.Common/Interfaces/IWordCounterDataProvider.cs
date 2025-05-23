namespace Db.WordCounter.Common.Interfaces;

public interface IWordCounterDataProvider
{
    void Init();

    IEnumerable<string> Next();
}
