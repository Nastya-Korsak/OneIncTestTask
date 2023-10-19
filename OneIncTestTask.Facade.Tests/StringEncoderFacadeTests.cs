using Moq;
using OneIncTestTask.Facade.Interfaces;
using OneIncTestTask.Facade.Services;
using OneIncTestTask.Utils.Interfaces;

namespace OneIncTestTask.Facade.Tests
{
    public class StringEncoderFacadeTests
    {
        private IStringEncoderFacade _fixture;
        private Mock<IStringEncoder> _stringEncoder;

        [SetUp]
        public void Init()
        {
            _stringEncoder = new Mock<IStringEncoder>();
            _fixture = new StringEncoderFacade(_stringEncoder.Object);
        }

        [Test]
        public void EncodeAsync_ArgumentIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _fixture.EncodeAsync(null!));
        }

        [Test]
        public async Task EncodeAsync_ArgumentIsCorrect_InvokeIStringEncoder()
        {
            var textToEncode = "string";

            await _fixture.EncodeAsync(textToEncode).ToListAsync();

            _stringEncoder.Verify(x => x.Encode(textToEncode), Times.Once);
        }

        [Test]
        public async Task EncodeAsync_ArgumentIsCorrect_ReturnCorrectResult()
        {
            var textToEncode = "string";
            var expectedResult = "c3RyaW5n";

            _stringEncoder.Setup(x => x.Encode(It.IsAny<string>())).Returns(expectedResult);

            var actualResult = await _fixture.EncodeAsync(textToEncode).ToListAsync();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}