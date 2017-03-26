// Copyright (c) Arch team. All rights reserved.

using System;
using System.Text;
using System.Security.Cryptography;

namespace Arch.Standard.Utils
{
    /// <summary>
    /// Provides the random utility which internal use random cryptography to implements the functionality.
    /// </summary>
    public class CryptoRandom
    {
        private static RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        /// <summary>
        /// Creates a random bytes, which's length specified by <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The length of the bytes.</param>
        /// <returns>The <paramref name="length"/> random bytes.</returns>
        public static byte[] CreateRandomBytes(int length)
        {
            var bytes = new byte[length];
            _rng.GetBytes(bytes);

            return bytes;
        }

        /// <summary>
        /// Creates a random key, which's length specified by the <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The length of the key.</param>
        /// <returns>A random key, which's length specified by the <paramref name="length"/>.</returns>
        public static string CreateRandomKey(int length)
        {
            var bytes = new byte[length];
            _rng.GetBytes(bytes);

            return Convert.ToBase64String(CreateRandomBytes(length));
        }

        /// <summary>
        /// Creates an unique key by the specified length.
        /// </summary>
        /// <param name="length">The length of key.</param>
        /// <returns>The unique key.</returns>
        public static string CreateUniqueKey(int length = 8) => CreateRandomBytes(length).ToHexString();

        /// <summary>
        /// Creates a series number prefix by <paramref name="prefix"/> and yyyyMMddHHmmss.
        /// </summary>
        /// <param name="prefix">The prefix of the series number.</param>
        /// <returns></returns>
        public static string CreateSeriesNumber(string prefix = "SW") => $"{prefix}{DateTime.Now.ToString("yyyyMMddHHmmss")}{CreateUniqueKey()}";
    }
}
