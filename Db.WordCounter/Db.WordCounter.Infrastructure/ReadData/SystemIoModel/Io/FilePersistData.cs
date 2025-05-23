using Db.WordCounter.Domain.Dtos.Occurrences;
using System.Text.Json;
using Db.WordCounter.Common.Interfaces;

namespace Db.WordCounter.Infrastructure.ReadData.SystemIoModel.Io;

public class FilePersistData : IFilePersistData
{
    private string directoryResultPath = ".\\ReadData\\SystemIoModel\\Io\\ResultData\\";

    public void SaveResultToFile(OccurrencesDto occurrencesDto)
    {
        if (occurrencesDto == null) return;

        string jsonString = JsonSerializer.Serialize(occurrencesDto);

        var directoryInfo = Directory.CreateDirectory(directoryResultPath);

        var fileName = $"{directoryInfo.FullName}\\{nameof(OccurrencesDto)}{DateTime.UtcNow.Ticks}.json";

        File.WriteAllText(fileName, jsonString);
    }

    public void SaveResultToAlphabetOrderOccurrencesFile(AlphabetOrderOccurrencesDto alphabetOrderOccurrencesDto)
    {
        if (alphabetOrderOccurrencesDto == null) return;

        var runDirectory = $"{directoryResultPath}{DateTime.UtcNow.Ticks}";

        var directoryInfo = Directory.CreateDirectory(runDirectory.ToString());

        foreach (var alphabet in alphabetOrderOccurrencesDto.AlphabetOrderOccurrencesModel)
        {
            var fileName = $"{directoryInfo.FullName}\\FILE_{alphabet.Key}.txt";

            using StreamWriter writer = File.CreateText(fileName);

            foreach (AlphabetOrderOccurrencesDetailDto alphabetContent in alphabet.Value)
            {
                writer.WriteLine(alphabetContent);
            }
        }
    }
}
