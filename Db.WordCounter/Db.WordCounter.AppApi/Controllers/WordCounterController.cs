using Db.WordCounter.AppApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace Db.WordCounter.AppApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WordCounterController : ControllerBase
{
    private readonly ILogger<WordCounterController> _logger;

    public WordCounterController(ILogger<WordCounterController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Count")]
    public ResponseWordCountModel Count()
    {
        return new ResponseWordCountModel
        {
            Count = 0,
        };
    }
}
