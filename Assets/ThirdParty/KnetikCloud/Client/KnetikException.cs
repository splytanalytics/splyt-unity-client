using System;
using com.knetikcloud.Utils;

namespace com.knetikcloud.Client
{
    /// <summary>
    /// Knetik Exception
    /// </summary>
    public class KnetikException : Exception
    {
        /// <summary>
        /// Gets or sets the error code (HTTP status code)
        /// </summary>
        /// <value>The error code (HTTP status code).</value>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error content (body json object)
        /// </summary>
        /// <value>The error content (Http response body).</value>
        public object ErrorContent { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikException"/> class.
        /// </summary>
        public KnetikException() {}

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikException"/> class.
        /// </summary>
        /// <param name="errorCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        public KnetikException(string message) : base(message)
        {
            ErrorCode = 0;

            KnetikLogger.LogError(string.Format("<EXCEPTION> {0}", message));
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikException"/> class.
        /// </summary>
        /// <param name="errorCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        public KnetikException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
            KnetikLogger.LogError(string.Format("<EXCEPTION> {0} - {1}", ErrorCode, message));
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikException"/> class.
        /// </summary>
        /// <param name="errorCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="errorContent">Error content.</param>
        public KnetikException(int errorCode, string message, object errorContent) : base(message)
        {
            ErrorCode = errorCode;
            ErrorContent = errorContent;
            KnetikLogger.LogError(string.Format("<EXCEPTION> {0} - {1}", ErrorCode, message));
        }
    }
}
