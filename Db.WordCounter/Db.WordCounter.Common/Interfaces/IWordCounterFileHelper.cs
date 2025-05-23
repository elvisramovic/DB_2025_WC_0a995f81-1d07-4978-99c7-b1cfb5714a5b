namespace Db.WordCounter.Common.Interfaces;

public interface IWordCounterFileHelper
{
    public IEnumerable<string> GetPathToFiles(string directoryPath);

    public IEnumerable<string> ReadAllLines(string filePath);
}
