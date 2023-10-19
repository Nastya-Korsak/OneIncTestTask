using OneIncTestTask.Utils.Interfaces;
using OneIncTestTask.Utils.Services;

namespace OneIncTestTask.Utils.Tests
{
    public class StringToBase64EncoderTests
    {
        private IStringEncoder _fixture;

        [SetUp]
        public void Init()
        {
            _fixture = new StringToBase64Encoder();
        }

        [Test]
        public void Encode_ArgumentIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _fixture.Encode(null!));
        }

        [Test]
        public void Encode_ArgumentIsCorrect_ReturnEncodedString()
        {
            var textToEncode = "string";
            var expectedResult = "c3RyaW5n";

            var actualResult = _fixture.Encode(textToEncode);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}