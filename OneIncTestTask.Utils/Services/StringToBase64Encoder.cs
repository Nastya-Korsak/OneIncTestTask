using OneIncTestTask.Utils.Interfaces;
using System.Text;

namespace OneIncTestTask.Utils.Services;

internal class StringToBase64Encoder : IStringEncoder
{
    public IEnumerable<char> Encode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var textBytes = Encoding.UTF8.GetBytes(value);
        var base64String = Convert.ToBase64String(textBytes);

        return base64String;
    }
}
