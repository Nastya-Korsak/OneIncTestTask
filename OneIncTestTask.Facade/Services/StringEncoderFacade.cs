using OneIncTestTask.Facade.Interfaces;
using OneIncTestTask.Utils.Interfaces;
using System.Runtime.CompilerServices;

namespace OneIncTestTask.Facade.Services;

internal class StringEncoderFacade : IStringEncoderFacade
{
    private readonly IStringEncoder _stringEncoder;
    public StringEncoderFacade(IStringEncoder stringEncoder)
    {
        _stringEncoder = stringEncoder;
    }

    public IAsyncEnumerable<char> EncodeAsync(string value, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(value);

        return EncodeAsyncInternal(value, cancellationToken);
    }

    private async IAsyncEnumerable<char> EncodeAsyncInternal(string value, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var encodedString = _stringEncoder.Encode(value);

        foreach (char c in encodedString)
        {

            var randomPause = new Random().Next(1000, 5000);
            await Task.Delay(randomPause, cancellationToken);

            yield return c;
        }
    }
}
