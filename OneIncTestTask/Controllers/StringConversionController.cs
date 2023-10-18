using Microsoft.AspNetCore.Mvc;
using OneIncTestTask.Facade.Interfaces;
using OneIncTestTask.Helpres;
using System.Net;

namespace OneIncTestTask.Controllers
{
    [ApiController]
    [Route("api/encode")]
    public class StringEncodingController : ControllerBase
    {
        private readonly ILogger<StringEncodingController> _logger;
        private readonly IStringEncoderFacade _stringEncoder;

        public StringEncodingController(
            ILogger<StringEncodingController> logger,
            IStringEncoderFacade stringEncoder)
        {
            _logger = logger;
            _stringEncoder = stringEncoder;
        }

        [HttpPost]
        public async Task EncodeTextAsync([FromBody] string text, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(text);

            _logger.LogInformation("Encoding started.");

            Response.Headers.Add("Content-Type", "text/event-stream");
            Response.StatusCode = (int)HttpStatusCode.OK;

            await foreach (var character in _stringEncoder.EncodeAsync(text).WithCancellation(cancellationToken))
            {
                await Response.WriteAsync(character.ToString(), cancellationToken);
                await Response.Body.FlushAsync(cancellationToken);
            }

            _logger.LogInformation("Encoding finished.");
        }
    }
}