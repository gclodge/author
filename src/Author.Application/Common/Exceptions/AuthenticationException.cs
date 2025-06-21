
namespace Author.Application.Common.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException() : base() { }

    public AuthenticationException(string message) : base(message) { }
}