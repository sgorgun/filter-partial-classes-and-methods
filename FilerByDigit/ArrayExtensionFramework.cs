using System;
using System.Collections.Generic;

namespace FilterByDigit
{
    /// <summary>
    /// Class that contains filter operations of arrays.
    /// </summary>
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterByPredicate(this int[]? source)
        {
            throw new NotImplementedException();
        }

        static partial void Verify(int item, ref bool match);
    }
}
