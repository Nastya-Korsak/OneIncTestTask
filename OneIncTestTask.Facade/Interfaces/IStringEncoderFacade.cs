using System.Runtime.CompilerServices;

namespace OneIncTestTask.Facade.Interfaces;

public interface IStringEncoderFacade
{
    IAsyncEnumerable<char> EncodeAsync(string value, CancellationToken cancellationToken = default);
}
