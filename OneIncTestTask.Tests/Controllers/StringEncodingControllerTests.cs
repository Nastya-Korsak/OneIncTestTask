using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using OneIncTestTask.Controllers;
using OneIncTestTask.Facade.Interfaces;

namespace OneIncTestTask.Tests.Controllers
{
    public class StringEncodingControllerTests
    {
        private Mock<ILogger<StringEncodingController>> _logger;
        private Mock<IStringEncoderFacade> _stringEncoder;
        private StringEncodingController _fixture;

        [SetUp]
        public void Init()
        {
            _logger = new Mock<ILogger<StringEncodingController>>();
            _stringEncoder = new Mock<IStringEncoderFacade>();
            _fixture = new StringEncodingController(_logger.Object, _stringEncoder.Object);
        }

        [Test]
        public void EncodeTextAsync_ArgumentIsNull_ThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _fixture.EncodeTextAsync(null!));
        }
    }
}