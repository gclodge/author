﻿namespace Author.Application.Common.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base() { }

    public ForbiddenAccessException(string message) : base(message) { }

    public ForbiddenAccessException(string message, Exception innerException)
        : base(message, innerException) { }
}