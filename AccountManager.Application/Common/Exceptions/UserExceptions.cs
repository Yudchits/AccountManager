using System;

namespace AccountManager.Application.Common.Exceptions
{
    public abstract class UserExceptionBase : Exception
    {
        public string PropertyName { get; private set; }

        public UserExceptionBase(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }

    public class BadRequestException : UserExceptionBase
    {
        public BadRequestException(string propertyName, string message)
            : base(propertyName, message)
        {
        }
    }

    public class NotFoundException : UserExceptionBase
    {
        public NotFoundException(string propertyName, string message)
            : base(propertyName, message)
        {
        }
    }

    public class ConflictException : UserExceptionBase
    {
        public ConflictException(string propertyName, string message)
            : base(propertyName, message)
        {
        }
    }

    public class AuthorizeException : UserExceptionBase
    {
        public AuthorizeException(string propertyName, string message)
            : base(propertyName, message)
        {
        }
    }
}