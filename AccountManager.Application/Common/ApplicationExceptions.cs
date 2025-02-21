using System;

namespace AccountManager.Application.Common
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }

    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    public class InternalServerException : Exception
    {
        public InternalServerException(string message) : base(message)
        {
        }
    }

    public class AuthorizeException : Exception
    {
        public AuthorizeException() : base("Пользователь не авторизован")
        {
        }

        public AuthorizeException(string message) : base(message)
        {
        }
    }
}