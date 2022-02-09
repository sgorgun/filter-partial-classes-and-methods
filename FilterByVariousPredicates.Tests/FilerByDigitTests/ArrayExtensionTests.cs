using System;
using System.Linq;
using FilterByDigit;
using NUnit.Framework;

namespace FilterByVariousPredicates.Tests.FilerByDigitTests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue })]
        [TestCase(new[] { -123, 123, 2202, 3333, 4444, 55055, 0, -7, 5402, 9, 0, -150, 287 }, 0, ExpectedResult = new[] { 2202, 55055, 0, 5402, 0, -150 })]
        [TestCase(new[] { -123, 123, 2202, 3333, 4444, 55055, 0, -7, 5402, 9, 0, -150, 287 }, 2, ExpectedResult = new[] { -123, 123, 2202, 5402, 287 })]
        [TestCase(new[] { -583, -7481, -24, -81001, -32, -10805 }, 8, ExpectedResult = new[] { -583, -7481, -81001, -10805 })]
        [TestCase(new[] { 111, 111, 111, 11111111 }, 1, ExpectedResult = new[] { 111, 111, 111, 11111111 })]
        [TestCase(new[] { -1, 0, 111, -11, -1 }, 1, ExpectedResult = new[] { -1, 111, -11, -1 })]
        [TestCase(new[] { int.MinValue, int.MinValue, int.MinValue, int.MaxValue, int.MaxValue }, 0, ExpectedResult = new int[] { })]
        public int[] FilterByPredicate_WithCorrectDigits_ReturnNewArray(int[] source, int digit)
        {
            ArrayExtension.Digit = digit;
            return source.FilterByPredicate();
        }

        [Test]
        public void FilterByPredicate_ArrayIsEmpty_ThrowArgumentException()
        {
            ArrayExtension.Digit = 0;
            Assert.Throws<ArgumentException>(() => Array.Empty<int>().FilterByPredicate(), "Array cannot be empty.");
        }

        [Test]
        public void FilterByPredicate_ArrayIsNull_ThrowArgumentNullException()
        {
            ArrayExtension.Digit = 0;
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => array.FilterByPredicate(), "Array cannot be null.");
        }

        [Test]
        public void FilterByPredicate_DigitLessZero_ThrowArgumentOutOfRangeException() => Assert.Throws<ArgumentOutOfRangeException>(
            () => ArrayExtension.Digit = -1, "Expected digit cannot be less than zero.");

        [Test]
        public void FilterByPredicate_DigitMoreThanNine_ThrowArgumentOutOfRangeException() => Assert.Throws<ArgumentOutOfRangeException>(
            () => ArrayExtension.Digit = 13, "Expected digit cannot be out of range 0..9.");

        [Test]
        public void FilterByPredicate_PerformanceTest()
        {
            const int sourceLength = 100_000_000,
                digit = 2,
                number = int.MaxValue;

            int[] source = new int[sourceLength];

            const int count = 1_000_000, step = sourceLength / count;

            for (int i = 0; i < sourceLength; i += step)
            {
                source[i] = number;
            }

            ArrayExtension.Digit = digit;

            int[] expected = Enumerable.Repeat(number, count).ToArray();

            int[] actual = source.FilterByPredicate();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
