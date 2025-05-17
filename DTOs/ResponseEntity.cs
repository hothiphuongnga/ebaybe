using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

public class ResponseEntity : IActionResult
{
    public int StatusCode { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Content { get; set; }

    public DateTime DateTime { get; set; }

    public ResponseEntity(int statusCode, object? content = null, string? message = null)
    {
        StatusCode = statusCode;
        Content = content;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        DateTime = System.DateTime.UtcNow;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var result = new ObjectResult(this)
        {
            StatusCode = this.StatusCode
        };

        await result.ExecuteResultAsync(context);
    }

    private string? GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad request",
            401 => "Unauthorized",
            403 => "Forbidden",
            404 => "Not found",
            500 => "Internal server error",
            _ => null
        };
    }
}
