using Microsoft.AspNetCore.Http;

namespace Author.Application.Common.Middleware;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception err)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = GetStatusCode(err);

            var errorMessage = GetErrorMessageJson(err);           
            var result = JsonSerializer.Serialize(new { message = errorMessage });
            await response.WriteAsync(result);
        }
    }

    static int GetStatusCode(Exception e)
    {
        return e switch
        {
            AppException => (int)HttpStatusCode.BadRequest,

            AuthenticationException => (int)HttpStatusCode.Unauthorized,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,

            ForbiddenAccessException => (int)HttpStatusCode.Forbidden,
            NotFoundException => (int)HttpStatusCode.NotFound,
       
            _ => (int)HttpStatusCode.InternalServerError,
        };
    }

    static string GetErrorMessageJson(Exception e)
    {
        return e switch
        {
            AppException 
            or NotFoundException 
            or AuthenticationException
            or UnauthorizedAccessException
            or ForbiddenAccessException => $"{e.Message}",
            _ => "Internal server error",
        };
    }
}