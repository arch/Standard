// Copyright (c) Arch team. All rights reserved.

using System;
using System.Text;

namespace Arch.Standard
{
    /// <summary>
    /// Provides some extension methods for byte[].
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts to base64 string.
        /// </summary>
        /// <param name="input">The input to convert.</param>
        /// <returns>The base64 string.</returns>
        public static string ToBase64String(this byte[] input) => Convert.ToBase64String(input);

        /// <summary>
        /// Converts to base64 string and replace it's '+' to '-', '/' to '_' and '=' to '%3d'.
        /// </summary>
        /// <param name="input">The input to convert</param>
        /// <returns>The base64 string and replace it's '+' to '-', '/' to '_' and '=' to '%3d'</returns>
        public static string ToUrlSuitable(this byte[] input) => input.ToBase64String().Replace("+", "-").Replace("/", "_").Replace("=", "%3d");

        /// <summary>
        /// Converts byte array to hex string.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The hex string.</returns>
        public static string ToHexString(this byte[] bytes)
        {
            var hex = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }
    }
}
