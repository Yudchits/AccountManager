using System;

namespace AccountManager.Application.Common
{
    public abstract class ApplicationExceptionBase : Exception
    {
        public string PropertyName { get; private set; }

        public ApplicationExceptionBase(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }

    public class BadRequestException : ApplicationExceptionBase
    {
        public BadRequestException(string propertyName, string message) 
            : base(propertyName, message)
        {
        }
    }

    public class ConflictException : ApplicationExceptionBase
    {
        public ConflictException(string propertyName, string message) 
            : base(propertyName, message)
        {
        }
    }

    public class NotFoundException : ApplicationExceptionBase
    {
        public NotFoundException(string propertyName, string message) 
            : base(propertyName, message)
        {
        }

        public NotFoundException(string message)
            : base(null, message)
        {
        }
    }

    public class InternalServerException : ApplicationExceptionBase
    {
        public InternalServerException(string message)
            : base(null, message)
        {
        }
    }
}