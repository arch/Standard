// Copyright (c) Arch team. All rights reserved.

using System.Text;
using System.Security.Cryptography;
#if NET461
using System.IO;
#else
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
#endif

namespace Arch.Standard
{
    /// <summary>
    /// Provides some extension methods for FCL encrpt and desrypt functionality.
    /// </summary>
    public static class CryptoExtensions
    {
        /// <summary>
        /// Encrypts the specified <paramref name="input"/> use triple DES.
        /// </summary>
        /// <param name="input">The input to encrypt.</param>
        /// <returns>The encrypted result.</returns>
        public static byte[] TripleDesEncrypt(this byte[] input)
        {
            return default(byte[]);
        }

        /// <summary>
        /// Decrypts the specified <paramref name="input"/> use triple DES.
        /// </summary>
        /// <param name="input">The input to descrypt.</param>
        /// <returns>The descrypted result.</returns>
        public static byte[] TripleDESDecrypt(this byte[] input)
        {
            return default(byte[]);
        }

        /// <summary>
        /// Encrypts the specified <paramref name="input"/> use DES.
        /// </summary>
        /// <param name="input">The input to encrypt.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The IV.</param>
        /// <param name="mode">The cipher mode.</param>
        /// <param name="paddingMode">The padding mode.</param>
        /// <returns>The encrypted result.</returns>
        public static byte[] DesEncrypt(this byte[] input, byte[] key, byte[] iv, CipherMode mode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.Zeros)
        {
#if NET461
            var des = new DESCryptoServiceProvider()
            {
                Key = key,
                IV = iv,
                Mode = mode,
                Padding = paddingMode
            };
            
            using(var ms = new MemoryStream())
            {
                using(var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(input, 0, input.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
#else
            var engine = new DesEngine();
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine), new ZeroBytePadding());
            cipher.Init(true, new ParametersWithIV(new DesParameters(key), iv));
            var rv = new byte[cipher.GetOutputSize(input.Length)];
            var tam = cipher.ProcessBytes(input, 0, input.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            return rv;
#endif
        }

        /// <summary>
        /// Encrypts the specified <paramref name="input"/> use DES.
        /// </summary>
        /// <param name="input">The input to encrypt.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The IV.</param>
        /// <param name="encoding">The encoding, the default value is gb2312</param>
        /// <returns>The encrypted result.</returns>
        public static byte[] DesEncrypt(this string input, byte[] key, byte[] iv, string encoding="gb2312") => Encoding.GetEncoding(encoding).GetBytes(input).DesEncrypt(key, iv);

        /// <summary>
        /// Decrypts the specified <paramref name="input"/> use DES.
        /// </summary>
        /// <param name="input">The input to encrypt.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The IV.</param>
        /// <param name="mode">The cipher mode.</param>
        /// <param name="paddingMode">The padding mode.</param>
        /// <returns>The descrypted result.</returns>
        public static byte[] DESDecrypt(this byte[] input, byte[] key, byte[] iv, CipherMode mode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.Zeros)
        {
#if NET461
            var des = new DESCryptoServiceProvider()
            {
                Key = key,
                IV = iv,
                Mode = mode,
                Padding = paddingMode
            };

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(input, 0, input.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
#else
            var engine = new DesEngine();
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine), new ZeroBytePadding());
            cipher.Init(false, new ParametersWithIV(new DesParameters(key), iv));
            var rv = new byte[cipher.GetOutputSize(input.Length)];
            var tam = cipher.ProcessBytes(input, 0, input.Length, rv, 0);

            cipher.DoFinal(rv, tam);

            return rv;
#endif
        }

        /// <summary>
        /// Decrypts the specified <paramref name="input"/> use DES.
        /// </summary>
        /// <param name="input">The input to encrypt.</param>
        /// <param name="key">The key.</param>
        /// <param name="iv">The IV.</param>
        /// <param name="encoding">The encoding, the default value is gb2312</param>
        /// <returns>The descrypted result.</returns>
        public static byte[] DESDecrypt(this string input, byte[] key, byte[] iv, string encoding = "gb2312") => Encoding.GetEncoding(encoding).GetBytes(input).DESDecrypt(key, iv);
    }
}
