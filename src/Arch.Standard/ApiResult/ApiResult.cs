// Copyright (c) Arch team. All rights reserved.

namespace Arch.Standard
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IApiResult"/> interface.
    /// </summary>
    public class ApiResult : IApiResult
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }

    /// <summary>
    /// Represents the default implementation of the <see cref="IApiResult{TResult}"/> interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class ApiResult<TResult> : ApiResult, IApiResult<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResult{TResult}" /> class.
        /// </summary>
        public ApiResult()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResult{TResult}" /> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        public ApiResult(TResult result, int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public TResult Result { get; set; }
    }
}
