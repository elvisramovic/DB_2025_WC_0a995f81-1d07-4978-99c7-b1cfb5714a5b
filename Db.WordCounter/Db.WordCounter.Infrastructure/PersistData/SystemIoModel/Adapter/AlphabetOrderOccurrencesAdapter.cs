using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Infrastructure.PersistData.SystemIoModel.Adapter;

public class AlphabetOrderOccurrencesAdapter
{
    private readonly string[] englishAlphabetSead = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z".Split(" ");

    public AlphabetOrderOccurrencesDto TransformModel(OccurrencesDto occurrencesDto)
    {
        if (occurrencesDto == null) return new AlphabetOrderOccurrencesDto();

        var alphabetOrderOccurrencesDto = new AlphabetOrderOccurrencesDto();

        foreach (var a in englishAlphabetSead)
        {
            alphabetOrderOccurrencesDto.AlphabetOrderOccurrencesModel.Add(a, new List<AlphabetOrderOccurrencesDetailDto>());
        }

        foreach (var wordCountModel in occurrencesDto.WordCountModel)
        {
            var keyLetter = wordCountModel.Key?.FirstOrDefault().ToString().ToUpper();

            if (keyLetter != null && alphabetOrderOccurrencesDto.AlphabetOrderOccurrencesModel.ContainsKey(keyLetter))
            {
                var alphabetOrderOccurrencesDetailDto = new AlphabetOrderOccurrencesDetailDto
                {
                    Count = wordCountModel.Value,
                    Word = wordCountModel.Key
                };

                alphabetOrderOccurrencesDto.AlphabetOrderOccurrencesModel[keyLetter].Add(alphabetOrderOccurrencesDetailDto);
            }
        }

        return alphabetOrderOccurrencesDto;
    }
}