using System;
using System.Globalization;

namespace CryptoCurrency.Application.Exceptions
{
    /// <summary>
    /// Class in charge of handling API exceptions
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Exception without message
        /// </summary>
        public ApiException() : base()
        {
        }

        /// <summary>
        /// Exception with message
        /// </summary>
        /// <param name="message">Exception message</param>
        public ApiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Exception with message and arguments
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="args">Arguments</param>
        public ApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        /// <summary>
        /// Exception with message and another exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}