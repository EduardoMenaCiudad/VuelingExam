using System;

namespace DFSLibrary
{
    public class NotFoundCurrencyException : Exception
    {
        public NotFoundCurrencyException(string message) : base(message)
        {
        }
    }
}
