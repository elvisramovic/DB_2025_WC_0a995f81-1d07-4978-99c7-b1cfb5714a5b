using Db.WordCounter.Common.Interfaces;
namespace Db.WordCounter.Infrastructure.PersistData.HttpModel;

public class CloudBlobProvider : IDataProvider
{
    public IEnumerable<string> GetCollecationData()
    {
        throw new NotImplementedException();
    }
}