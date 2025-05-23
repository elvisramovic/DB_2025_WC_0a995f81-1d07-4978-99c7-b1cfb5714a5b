using Db.WordCounter.Common.Interfaces;

namespace Db.WordCounter.Infrastructure.ReadData.SystemIoModel.Provider;
public class FileWordCounterDataProvider : IWordCounterDataProvider
{
    private readonly IWordCounterFileHelper _wordCounterFileHelper;
    private readonly string _directoryPath = string.Empty;
    private Stack<string> stockDataModel = new();

    public FileWordCounterDataProvider(IWordCounterFileHelper wordCounterFileHelper, string directoryPath)
    {
        _wordCounterFileHelper = wordCounterFileHelper;
        _directoryPath = directoryPath;
    }

    public void Init()
    {
        var files = _wordCounterFileHelper.GetPathToFiles(_directoryPath);

        stockDataModel = new Stack<string>(files);
    }

    public IEnumerable<string> Next()
    {
        if (stockDataModel.Any())
        {
            var allLines = _wordCounterFileHelper.ReadAllLines(stockDataModel.Pop());

            return allLines;
        }

        return Enumerable.Empty<string>();
    }
}
