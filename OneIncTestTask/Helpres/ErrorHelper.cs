using System.Net;
using System.Text.Json;

namespace OneIncTestTask.Helpres;

internal static class ErrorHelper
{
    public static  string CreateError(HttpStatusCode statusCode, string message)
    {
        return JsonSerializer.Serialize(new
        {
            StatusCode = statusCode,
            Message = message
        });
    }
}
