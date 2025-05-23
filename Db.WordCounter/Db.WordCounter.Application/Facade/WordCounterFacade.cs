using Db.WordCounter.Common.Interfaces;
using Db.WordCounter.Domain.Dtos.Occurrences;

namespace Db.WordCounter.Application.Facade;

public class WordCounterFacade : IWordCounterFacade
{
    private readonly IWordsCountAlgoStrategyFactory _wordsCountAlgoStrategyFactory;
    private readonly IWordCounterDataProvider _wordCounterDataProvider;

    public WordCounterFacade(IWordsCountAlgoStrategyFactory wordsCountAlgoStrategyFactory, IWordCounterDataProvider wordCounterDataProvider)
    {
        _wordsCountAlgoStrategyFactory = wordsCountAlgoStrategyFactory;
        _wordCounterDataProvider = wordCounterDataProvider;
    }

    public OccurrencesDto CountWords(CountWordsAlgoType algoType)
    {
        var algoInstance = _wordsCountAlgoStrategyFactory.CreateInstance(algoType);

        _wordCounterDataProvider.Init();

        var isProcessing = true;
        do
        {
            var nextFile = _wordCounterDataProvider.Next();

            if (nextFile.Any())
            {
                algoInstance.CountWords(nextFile);
            }
            else
            {
                isProcessing = false;
            }
        } while (isProcessing);

        return new OccurrencesDto
        {
            WordCountModel = algoInstance.GetWordCountModel()

        };
    }
}
