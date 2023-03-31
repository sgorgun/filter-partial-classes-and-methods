using System;

namespace FilterByPalindromic
{
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Creates new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterByPredicate(this int[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"{nameof(source)} can't be empty.", nameof(source));
            }

            List<int> result = new List<int>();

            foreach (int item in source)
            {
                if (Verify(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        private static partial bool Verify(int item);
    }
}
