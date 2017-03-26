// Copyright (c) Arch team. All rights reserved.

namespace Arch.Standard
{
    /// <summary>
    /// Provides the interfaces for a empty api result.
    /// </summary>
    public interface IApiResult
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>The status code.</value>
        int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        string Message { get; set; }
    }

    /// <summary>
    /// Provides the interfaces for a generic api result.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IApiResult<TResult> : IApiResult
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        TResult Result { get; set; }
    }
}
