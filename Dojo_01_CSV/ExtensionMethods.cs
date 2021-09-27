using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo_01_CSV
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Splits a given string, by a given string removing empty entries
        /// </summary>
        /// <param name="s">The string to splitt</param>
        /// <param name="splitString">The string to split by</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitByString(this string s, string splitString)
        {
            string[] values = s.Split(new[] { splitString }, StringSplitOptions.RemoveEmptyEntries);

            return values.ToList();
        }
    }
}