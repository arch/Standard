// Copyright (c) Arch team. All rights reserved.

using System.Security.Cryptography;
using System.Text;

namespace Arch.Standard
{
    /// <summary>
    /// Provides some extension methods for string hashing.
    /// </summary>
    public static class HashExtensions
    {
        private static byte[] _empty = new byte[0];

        /// <summary>
        /// Creates the hash of the <paramref name="plainText"/> by the specified <paramref name="hashAlgorithm"/> and <paramref name="encoding"/>.
        /// </summary>
        /// <param name="plainText">The plain text to hash.</param>
        /// <param name="hashAlgorithm">The hash algorithm, if specify null, will use MD5 algorithm.</param>
        /// <param name="encoding">The encoding, the default value is gb2312</param>
        /// <returns>The hashed value.</returns>
        public static byte[] Hash(this string plainText, HashAlgorithm hashAlgorithm, string encoding = "gb2312")
        {
            // get bytes from the plaintext
            var bytes = Encoding.GetEncoding(encoding).GetBytes(plainText);

            // encrypt
            using (var algorithm = hashAlgorithm ?? System.Security.Cryptography.MD5.Create())
            {
                return algorithm.ComputeHash(bytes);
            }
        }

        /// <summary>
        /// Creates a MD5 hash of the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="encoding">The encoding, the default value is gb2312</param>
        /// <returns>The MD5 hash of the specified <paramref name="input"/>.</returns>
        public static byte[] MD5(this string input, string encoding = "gb2312")
        {
            if (string.IsNullOrEmpty(input))
                return _empty;

            return Hash(input, System.Security.Cryptography.MD5.Create(), encoding);
        }

        /// <summary>
        /// Creates a SHA512 hash of the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="encoding">The encoding, the default value is gb2312</param>
        /// <returns>The SHA512 hash of the specified <paramref name="input"/>, the value is base64 string.</returns>
        public static byte[] Sha512(this string input, string encoding = "gb2312")
        {
            if (string.IsNullOrEmpty(input))
                return _empty;

            return Hash(input, SHA512.Create(), encoding);
        }

        /// <summary>
        /// Creates a SHA256 hash of the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="encoding">The encoding, the default value is gb2312</param>
        /// <returns>The SHA256 hash of the specified <paramref name="input"/>, the value is base64 string.</returns>
        public static byte[] Sha256(this string input, string encoding = "gb2312")
        {
            if (string.IsNullOrEmpty(input))
                return _empty;

            return Hash(input, SHA256.Create());
        }

        /// <summary>
        /// Creates a SHA1 hash of the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="encoding">The encoding, the default value is gb2312</param>
        /// <returns>The hashed value.</returns>
        public static byte[] Sha1(this string input, string encoding = "gb2312")
        {
            if (string.IsNullOrEmpty(input))
                return _empty;

            return Hash(input, SHA1.Create());
        }

        /// <summary>
        /// Creates a SHA256 hash of the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The SHA256 hash of the specified <paramref name="input"/>.</returns>
        public static byte[] Sha256(this byte[] input)
        {
            if (input == null)
            {
                return null;
            }

            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(input);
            }
        }
    }
}
