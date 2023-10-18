﻿using System.Runtime.Serialization;

namespace CarProjectMVC.Exceptions
{
    /// <summary>
    /// Исключение, означающее что сервер не смог обнаружить необходимый токен для аутентификации.
    /// </summary>
    [Serializable]
    internal class TokenNotExistException : Exception
    {
        public TokenNotExistException()
        {
        }

        public TokenNotExistException(string? message) : base(message)
        {
        }

        public TokenNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TokenNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}