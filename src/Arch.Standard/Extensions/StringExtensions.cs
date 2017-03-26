// Copyright (c) Arch team. All rights reserved.

using System;
using System.Text;

namespace Arch.Standard
{
    /// <summary>
    /// Provides some extension methods for <see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes trim string from the current String object.
        /// </summary>
        /// <param name="source">current string object</param>
        /// <param name="trim">trim string object</param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string TrimStart(this string source, string trim, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (source == null)
            {
                return null;
            }

            string s = source;
            while (s.StartsWith(trim, stringComparison))
            {
                s = s.Substring(trim.Length);
            }

            return s;
        }

        /// <summary>
        /// Removes trim string from the current String object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
        public static string TrimAfter(this string source, string trim)
        {
            int index = source.IndexOf(trim, StringComparison.Ordinal);
            if (index > 0)
            {
                source = source.Substring(0, index);
            }

            return source;
        }

        /// <summary>
        /// Escapes the string for MySQL.
        /// </summary>
        /// <param name="value">The value to escape</param>
        /// <returns>The string with all quotes escaped.</returns>
        public static string MySQLEscape(this string value)
        {
            if (!IsQuoting(value))
                return value;

            var sb = new StringBuilder();
            foreach (var c in value)
            {
                var charClass = charClassArray[c];
                if (charClass != CharKinds.None)
                {
                    sb.Append("\\");
                }
                sb.Append(c);
            }

            return sb.ToString();
        }

        #region MySQLEscape Helpers

        enum CharKinds : byte
        {
            None,
            Quote,
            Backslash
        }

        private static string backslashChars = "\u005c\u00a5\u0160\u20a9\u2216\ufe68\uff3c";
        private static string quoteChars = "\u0022\u0027\u0060\u00b4\u02b9\u02ba\u02bb\u02bc\u02c8\u02ca\u02cb\u02d9\u0300\u0301\u2018\u2019\u201a\u2032\u2035\u275b\u275c\uff07";

        private static CharKinds[] charClassArray = MakeCharClassArray();

        private static CharKinds[] MakeCharClassArray()
        {

            var a = new CharKinds[65536];
            foreach (var c in backslashChars)
            {
                a[c] = CharKinds.Backslash;
            }
            foreach (var c in quoteChars)
            {
                a[c] = CharKinds.Quote;
            }

            return a;
        }

        private static bool IsQuoting(string str)
        {
            foreach (var c in str)
            {
                if (charClassArray[c] != CharKinds.None)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
