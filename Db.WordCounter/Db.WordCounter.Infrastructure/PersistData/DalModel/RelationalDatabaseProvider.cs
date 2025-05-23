using Db.WordCounter.Common.Interfaces;

namespace Db.WordCounter.Infrastructure.PersistData.DalModel;
public class RelationalDatabaseProvider : IDataProvider
{
    public IEnumerable<string> GetCollecationData()
    {
        throw new NotImplementedException();
    }
}

