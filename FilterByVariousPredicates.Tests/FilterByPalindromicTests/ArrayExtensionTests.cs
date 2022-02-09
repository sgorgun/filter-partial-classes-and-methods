using System;
using System.Linq;
using FilterByPalindromic;
using NUnit.Framework;

namespace FilterByVariousPredicates.Tests.FilterByPalindromicTests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 717, 828, 45, 58, 881, 11711, 252 }, ExpectedResult = new[] { 717, 828, 11711, 252 })]
        [TestCase(new[] { 17, 82, 45, 58, 881, 117, 25 }, ExpectedResult = new int[] { })]
        [TestCase(new[] { 2212332, 0, 1405644, 12345, 1, -1236674, 123321, 1111111 }, ExpectedResult = new[] { 0, 1, 123321, 1111111 })]
        [TestCase(new[] { 1111111112, 987654, -24, 1234654321, 32, 1005 }, ExpectedResult = new int[] { })]
        [TestCase(new[] { -27, 987656789, 7557, int.MaxValue, 7556, 7243, 7243427, int.MinValue }, ExpectedResult = new[] { 987656789, 7557, 7243427 })]
        [TestCase(new[] { 111, 111, 111, 11111111 }, ExpectedResult = new[] { 111, 111, 111, 11111111 })]
        [TestCase(new[] { -1, 0, 111, -11, -1 }, ExpectedResult = new[] { 0, 111 })]
        [TestCase(new[] { 0, 1, 2, 3, 4 }, ExpectedResult = new[] { 0, 1, 2, 3, 4 })]
        public int[] FilterByPredicateTests(int[] source)
            => source.FilterByPredicate();

        [Test]
        public void FilterByPredicate_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
            () => Array.Empty<int>().FilterByPredicate(), "Array cannot be empty.");

        [Test]
        public void FilterByPredicate_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
            () => ArrayExtension.FilterByPredicate(null), "Array cannot be null.");

        [Test]
        public void FilterByPredicate_PerformanceTest()
        {
            const int sourceLength = 10_000_000;
            const int palindromic = 1_234_554_321;
            int[] source = Enumerable.Repeat(int.MaxValue, sourceLength).ToArray();
            const int count = 1_000_000, step = sourceLength / count;

            for (int i = 0; i < sourceLength; i += step)
            {
                source[i] = palindromic;
            }

            int[] expected = Enumerable.Repeat(palindromic, count).ToArray();
            int[] actual = source.FilterByPredicate();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
