using System;

namespace AccountManager.Application.Common.Exceptions
{
    public class UserAccountBookmarkException : Exception
    {
        public UserAccountBookmarkException(string message) : base(message)
        {
        }

        public UserAccountBookmarkException()
            : this("Достигнут лимит количества закладок")
        {
        }
    }
}