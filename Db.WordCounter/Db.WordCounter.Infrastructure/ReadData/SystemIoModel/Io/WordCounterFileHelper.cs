using Db.WordCounter.Common.Interfaces;

namespace Db.WordCounter.Infrastructure.ReadData.SystemIoModel.Io;

public class WordCounterFileHelper : IWordCounterFileHelper
{
    private const int maxFileSize_10mb = 10 * 1048576;

    public IEnumerable<string> ReadAllLines(string filePath)
    {
        var allLines = File.ReadAllLines(filePath);

        return allLines;
    }

    public IEnumerable<string> GetPathToFiles(string directoryPath)
    {
        try
        {
            var source = new DirectoryInfo(directoryPath);

            if (!source.Exists)
            {
                return Enumerable.Empty<string>();

            }

            FileInfo[] fiArr = source.GetFiles();

            IList<string> filesMaxFileSize = new List<string>();

            foreach (FileInfo fi in fiArr)
            {
                if (fi.Length < maxFileSize_10mb)
                {
                    filesMaxFileSize.Add(fi.FullName);
                }
            }

            return filesMaxFileSize.ToArray();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
