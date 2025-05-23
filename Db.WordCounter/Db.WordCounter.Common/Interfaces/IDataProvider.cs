namespace Db.WordCounter.Common.Interfaces;

public interface IDataProvider
{
    public IEnumerable<string> GetCollecationData();
}